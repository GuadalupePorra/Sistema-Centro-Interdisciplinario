using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCI
{
    internal class PagoDAO
    {
        private readonly Conexion _conexion;

        public PagoDAO()
        {
            _conexion = new Conexion();
        }

        public bool RegistrarPagoYActualizarTurno(Pago pago)
        {
            using (var conn = _conexion.ObtenerConexion())
            using (var transaction = conn.BeginTransaction())
            {
                try
                {
                    // Verificar el estado del turno antes de registrar el pago
                    string verificarEstadoQuery = "SELECT estado FROM turno WHERE id_turno = @idTurno";
                    using (var cmdVerificar = new MySqlCommand(verificarEstadoQuery, conn, transaction))
                    {
                        cmdVerificar.Parameters.AddWithValue("@idTurno", pago.IdTurno);
                        string estadoActual = cmdVerificar.ExecuteScalar()?.ToString();

                        if (estadoActual == null || estadoActual.ToUpper() != "CONFIRMADO")
                        {
                            throw new InvalidOperationException("El turno no está en estado CONFIRMADO.");
                        }
                    }

                    // Insertar el pago
                    string insertPagoQuery = @"INSERT INTO pago (id_turno, fecha_pago, monto, medio_pago, ruta_recibo)
                                       VALUES (@idTurno, @fechaPago, @monto, @medioPago,@rutaRecibo)";

                    using (var cmd = new MySqlCommand(insertPagoQuery, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@idTurno", pago.IdTurno);
                        cmd.Parameters.AddWithValue("@fechaPago", pago.FechaPago);
                        cmd.Parameters.AddWithValue("@monto", pago.Monto);
                        cmd.Parameters.AddWithValue("@medioPago", pago.MedioPago);
                        cmd.Parameters.AddWithValue("@rutaRecibo", pago.RutaRecibo); // 👈 nueva línea
                        cmd.ExecuteNonQuery();
                    }

                    // 3. Actualizar el estado del turno a PAGADO
                    string updateTurnoQuery = "UPDATE turno SET estado = 'PAGADO' WHERE id_turno = @idTurno";
                    using (var cmd = new MySqlCommand(updateTurnoQuery, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@idTurno", pago.IdTurno);
                        cmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    return true;
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show(ex.Message, "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    transaction.Rollback();
                    return false;
                }
                catch
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }

        public List<PagoVista> ObtenerPagosFiltrados(
    string periodo,
    string filtroPaciente = "",
    string especialidad = "",
    int? idProfesional = null,
    int limite = 20,
    int offset = 0)
        {
            using (var conn = _conexion.ObtenerConexion())
            {
                string condicionFecha = "";
                string condicionPaciente = "";
                string condicionEspecialidad = "";
                string condicionProfesional = "";

                // Filtrado por período
                switch (periodo?.ToUpper())
                {
                    case "DIARIO":
                        condicionFecha = "AND DATE(p.fecha_pago) = CURDATE()";
                        break;
                    case "SEMANAL":
                        condicionFecha = "AND YEARWEEK(p.fecha_pago, 1) = YEARWEEK(CURDATE(), 1)";
                        break;
                    case "MENSUAL":
                        condicionFecha = "AND MONTH(p.fecha_pago) = MONTH(CURDATE()) AND YEAR(p.fecha_pago) = YEAR(CURDATE())";
                        break;
                }

                // Filtro por paciente
                if (!string.IsNullOrWhiteSpace(filtroPaciente))
                {
                    condicionPaciente = "AND (pa.dni LIKE @FiltroPaciente OR pa.apellido LIKE @FiltroPaciente)";
                }

                // Filtro por especialidad
                if (!string.IsNullOrWhiteSpace(especialidad))
                {
                    condicionEspecialidad = "AND e.especialidad = @Especialidad";
                }

                // Filtro por ID de profesional
                if (idProfesional.HasValue)
                {
                    condicionProfesional = "AND pr.id_profesional = @IdProfesional";
                }

                string sql = $@"
            SELECT 
                p.fecha_pago AS FechaPago,
                p.monto AS Monto,
                p.medio_pago AS MedioPago,

                CONCAT(pa.nombre, ' ', pa.apellido) AS NombrePaciente,
                pa.dni AS DniPaciente,

                 CONCAT(pr.nombre, ' ', pr.apellido) AS NombreProfesional,
                e.especialidad AS Especialidad,

                t.fecha AS FechaTurno,
                t.hora_inicio AS HoraTurno

            FROM pago p
            JOIN turno t ON p.id_turno = t.id_turno
            JOIN paciente pa ON t.paciente_id = pa.id_paciente
            JOIN profesional pr ON t.profesional_id = pr.id_profesional
            JOIN especialidades e ON pr.id_especialidad = e.id_especialidad

            WHERE 1=1
            {condicionFecha}
            {condicionPaciente}
            {condicionEspecialidad}
            {condicionProfesional}

            ORDER BY p.fecha_pago DESC
            LIMIT @Limite OFFSET @Offset;
        ";

                return conn.Query<PagoVista>(sql, new
                {
                    FiltroPaciente = $"{filtroPaciente}%",
                    Especialidad = especialidad,
                    IdProfesional = idProfesional,
                    Limite = limite,
                    Offset = offset
                }).ToList();
            }
        }

    }


}
