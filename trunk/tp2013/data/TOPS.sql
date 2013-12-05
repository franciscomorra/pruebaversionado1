USE [GD2C2013]
GO
/****** Object:  StoredProcedure [SHARPS].[InsertEspecialidad]    Script Date: 11/20/2013 16:21:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*Top 5 de las especialidades que más se registraron cancelaciones, 
tanto de afiliados como de profesionales*/

CREATE PROCEDURE [SHARPS].Get_TOPCancelaciones

	@fecha_inicio AS datetime,
	@fecha_fin AS datetime
AS
BEGIN
	SELECT TOP 5 e.Descripcion 	,COUNT (e.Descripcion) AS Cantidad
		FROM [SHARPS].Especialidades e
		INNER JOIN [SHARPS].Turnos t ON t.Especialidad = e.Codigo
		INNER JOIN [SHARPS].Estados_Turno et ON et.EstadoID = t.Estado
		INNER JOIN [SHARPS].Agendas ag ON ag.AgendaID = t.Agenda
		WHERE (et.Descripcion = 'CanceladoAfiliado' OR et.Descripcion = 'CanceladoProfesional')
		AND ag.Horario BETWEEN @fecha_inicio AND @fecha_fin
		GROUP BY   e.Descripcion
		ORDER BY Cantidad desc
END


 /*Top 5 de la cantidad total de bonos farmacia vencidos por afiliado*/
 
CREATE PROCEDURE [SHARPS].Get_TOPVencidos

	@fecha_inicio AS datetime,
	@fecha_fin AS datetime
AS
BEGIN
	
	SELECT TOP 5 a.UsuarioID,	COUNT (bf.Numero) AS Cantidad
		FROM [SHARPS].Bonos_Farmacia bf
		INNER JOIN [SHARPS].Compras c ON c.CompraID = bf.Compra
		INNER JOIN [SHARPS].Afiliados a ON a.UsuarioID = c.Afiliado
		WHERE NOT EXISTS(SELECT * from Recetas AS r WHERE bf.Numero = r.Bono_Farmacia) AND
		CAST (bf.Fecha_Impresion AS int) BETWEEN (CAST(@fecha_inicio AS int))AND (CAST (@fecha_fin AS int) -60)
		GROUP BY   a.UsuarioID
		ORDER BY Cantidad Desc
END


/*Top 5 de las especialidades de médicos con más bonos de farmacia recetados*/

CREATE PROCEDURE [SHARPS].Get_TOPRecetados 

	@fecha_inicio AS datetime,
	@fecha_fin AS datetime
AS
BEGIN
	SELECT TOP 5 e.Descripcion, COUNT(r.Bono_Farmacia) As Cantidad
		FROM [SHARPS].Especialidades e
		INNER JOIN [SHARPS].Turnos t ON t.Especialidad = e.Codigo
		INNER JOIN [SHARPS].Afiliados a ON a.UsuarioID = t.Afiliado
		INNER JOIN [SHARPS].Planes_Medicos pm ON pm.Codigo = a.Plan_Medico
		INNER JOIN [SHARPS].Bonos_Farmacia bf ON bf.PlanMedico = pm.Codigo
		INNER JOIN [SHARPS].Recetas r ON r.Bono_Farmacia = bf.Numero
		WHERE (bf.Numero = r.Bono_Farmacia) AND (bf.Fecha_Impresion BETWEEN @fecha_inicio AND @fecha_fin)
		GROUP BY   e.Descripcion 
		ORDER BY Cantidad Desc
END


/*Top 10 de los afiliados que utilizaron bonos que ellos mismo no compraron*/ 

CREATE PROCEDURE [SHARPS].Get_TOPVividores 

	--@fecha_inicio AS datetime,
	--@fecha_fin AS datetime
AS
BEGIN
	SELECT TOP 10 a.UsuarioID 
		FROM [SHARPS].Afiliados a
		INNER JOIN [SHARPS].Planes_Medicos p ON p.Codigo = a.Plan_Medico
		INNER JOIN [SHARPS].Bonos_Consulta bc ON bc.PlanMedico = p.Codigo-- antes puse codigo1 y codigo2 pero no se si los toma
		INNER JOIN [SHARPS].Consultas c ON c.Bono_Consulta = bc.Numero
		INNER JOIN [SHARPS].Bonos_Farmacia bf ON bf.PlanMedico = p.Codigo
		INNER JOIN [SHARPS].Recetas r ON r.Bono_Farmacia = bf.Numero
		INNER JOIN [SHARPS].Compras c ON c.Afiliado= a.UsuarioID
		WHERE NOT EXISTS(SELECT * from Compras AS c WHERE c.Afiliado = a.UsuarioID) --AND ???  BETWEEN @fecha_inicio AND @fecha_fin
		GROUP BY   a.UsuarioID
		ORDER BY 1 desc
END
