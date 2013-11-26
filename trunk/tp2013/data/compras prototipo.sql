/*INSERT INTO [SHARPS].Compras (Precio_BonoConsulta , Precio_BonoFarmacia , Afiliado , fecha_Compra)
SELECT  m.Plan_Med_Precio_Bono_Consulta , m.Plan_Med_Precio_Bono_Farmacia , U.UsuarioID , m.Compra_Bono_Fecha , m.Bono_Farmacia_Numero
FROM gd_esquema.Maestra m
INNER JOIN SHARPS.Usuarios U ON U.Username =  CAST(m.Paciente_DNI AS Nvarchar(MAX))
WHERE m.Turno_Fecha is NULL AND m.Bono_Farmacia_Numero is not null  
order by m.Compra_Bono_Fecha , U.UsuarioID , m.Bono_Farmacia_Numero

INSERT INTO [SHARPS].Bonos_Farmacia (Numero, Fecha_Impresion, Compra ,PlanMedico)
SELECT DISTINCT m.Bono_Farmacia_Numero , m.Bono_Farmacia_Fecha_Impresion , C.CompraID , m.Plan_Med_Codigo
FROM gd_esquema.Maestra m
INNER JOIN SHARPS.Usuarios U ON U.Username =  CAST(m.Paciente_DNI AS Nvarchar(MAX))
INNER JOIN SHARPS.Compras C ON U.UsuarioID = C.Afiliado 
WHERE  m.Bono_Farmacia_Numero is not null */


delete SHARPS.Compras 
delete SHARPS.Bonos_Farmacia
delete SHARPS.Bonos_Consulta

CREATE TABLE #compras(
CodID int identity (1,1) ,
Precio_Consulta int ,
Precio_Farmacia int,
usuario int,
Fecha_Compra date,
numero_Bono int,
plan_Medico int,
tipo_Bono nvarchar (50),
Fecha_Impresion date
)

--PARA FARMACIA
INSERT INTO  #compras (Precio_Consulta, Precio_Farmacia , usuario, Fecha_Compra, numero_Bono, plan_Medico, tipo_Bono, Fecha_Impresion)
SELECT  m.Plan_Med_Precio_Bono_Consulta , m.Plan_Med_Precio_Bono_Farmacia , U.UsuarioID , m.Compra_Bono_Fecha , m.Bono_Farmacia_Numero  , M.Plan_Med_Codigo ,'farmacia', m.Bono_Farmacia_Fecha_Impresion
FROM gd_esquema.Maestra m
INNER JOIN SHARPS.Usuarios U ON U.Username =  CAST(m.Paciente_DNI AS Nvarchar(255))
WHERE m.Turno_Fecha is NULL AND m.Bono_Farmacia_Numero is not null  

---AHORA UNO PARA CONSULTAS

INSERT INTO  #compras (Precio_Consulta, Precio_Farmacia , usuario, Fecha_Compra, numero_Bono, plan_Medico, tipo_Bono, Fecha_Impresion)
SELECT  m.Plan_Med_Precio_Bono_Consulta , m.Plan_Med_Precio_Bono_Farmacia , U.UsuarioID , m.Compra_Bono_Fecha , m.Bono_Consulta_Numero  , M.Plan_Med_Codigo ,'consultas', m.Bono_Consulta_Fecha_Impresion
FROM gd_esquema.Maestra m
INNER JOIN SHARPS.Usuarios U ON U.Username =  CAST(m.Paciente_DNI AS Nvarchar(255))
WHERE m.Turno_Fecha is NULL AND m.Bono_Consulta_Numero is not null  



--select * from #compras

--DROP table #compras

INSERT INTO [SHARPS].Compras (Precio_BonoConsulta , Precio_BonoFarmacia , Afiliado , fecha_Compra)
SELECT  C.Precio_Consulta , C.Precio_Farmacia, C.usuario, C.Fecha_Compra
FROM #compras C


--select * from SHARPS.Compras

INSERT INTO SHARPS.Bonos_Farmacia(Numero , Fecha_Impresion , PlanMedico , Compra)
select  C.numero_Bono , C.Fecha_Impresion , C.plan_Medico , C.CodID
from #compras C
INNER JOIN SHARPS.Compras CO ON CO.CompraID = C.CodID
where C.tipo_Bono = 'farmacia'

INSERT INTO SHARPS.Bonos_Consulta(Numero , Fecha_Impresion , PlanMedico , Compra)
select  C.numero_Bono , C.Fecha_Impresion , C.plan_Medico , C.CodID
from #compras C
INNER JOIN SHARPS.Compras CO ON CO.CompraID = C.CodID
where C.tipo_Bono = 'consultas'


 