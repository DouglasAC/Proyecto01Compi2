﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto_CQL_T.Respuestas;

namespace Proyecto_CQL_T.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaquetesLUPController : ControllerBase
    {

        public ActionResult Post([FromBody] PaquetesLUP paquete)
        {
            Console.WriteLine(paquete.paquete);
            return Ok(new PaquetesLUP("[+message]mensajes a imprimir consola[-message][+ERROR][+LINE]40[-LINE][+COLUMN]50[-COLUMN][+TYPE]LEXICO[-TYPE][+DESC]NO SE RECONOCIO + [-DESC][-ERROR][+message]mensaje a consola1[-message][+data]<table><tr><th>Hoy</th><th>Mañana</th><th>Viernes</th></tr><tr><td>Soleado</td><td>Mayormente soleado</td><td>Parcialmente nublado</td></tr><tr><td>19°C</td><td>17°C</td><td>12°C</td></tr></table>[-data][+DATABASES]     [+DATABASE]         [+NAME]             base_no_1         [-NAME]         [+TABLES]             [+TABLE]                 [+NAME]                     tabla_1_base_1                 [-NAME]                 [+COLUMNS]                     [+COLUMN]                         [+NAME]                             col_1                         [-NAME]                         [+TIPO]                             INT                         [-TIPO]                         [+PK]                             TRUE                         [-PK]                     [-COLUMN]                     [+COLUMN]                         [+NAME]                             col_2                         [-NAME]                         [+TIPO]                             string                         [-TIPO]                         [+PK]                             false                         [-PK]                     [-COLUMN]                     [+COLUMN]                         [+NAME]                             col_3                         [-NAME]                         [+TIPO]                             date                         [-TIPO]                         [+PK]                             false                         [-PK]                     [-COLUMN]                 [-COLUMNS]             [-TABLE]             [+TABLE]                 [+NAME]                     tabla_1_base_1                 [-NAME]                 [+COLUMNS]                     [+COLUMN]                         [+NAME]                             col_1                         [-NAME]                         [+TIPO]                             INT                         [-TIPO]                         [+PK]                             TRUE                         [-PK]                     [-COLUMN]                     [+COLUMN]                         [+NAME]                             col_2                         [-NAME]                         [+TIPO]                             string                         [-TIPO]                         [+PK]                             false                         [-PK]                     [-COLUMN]                     [+COLUMN]                         [+NAME]                             col_3                         [-NAME]                         [+TIPO]                             date                         [-TIPO]                         [+PK]                             false                         [-PK]                     [-COLUMN]                 [-COLUMNS]             [-TABLE]             [+TABLE]                 [+NAME]                     tabla_1_base_1                 [-NAME]                 [+COLUMNS]                     [+COLUMN]                         [+NAME]                             col_1                         [-NAME]                         [+TIPO]                             INT                         [-TIPO]                         [+PK]                             TRUE                         [-PK]                     [-COLUMN]                     [+COLUMN]                         [+NAME]                             col_2                         [-NAME]                         [+TIPO]                             string                         [-TIPO]                         [+PK]                             false                         [-PK]                     [-COLUMN]                     [+COLUMN]                         [+NAME]                             col_3                         [-NAME]                         [+TIPO]                             date                         [-TIPO]                         [+PK]                             false                         [-PK]                     [-COLUMN]                 [-COLUMNS]             [-TABLE]                       [-TABLES]          [+TYPES]             [+TYPEUS]                 [+NAME]                     animal                 [-NAME]                 [+ATRIBUTES]                     [+ATRIBUTE]                         [+NAME]                             nombre                         [-NAME]                         [+TIPO]                             STRING                         [-TIPO]                     [-ATRIBUTE]                     [+ATRIBUTE]                         [+NAME]                             edad                         [-NAME]                         [+TIPO]                             int                         [-TIPO]                     [-ATRIBUTE]                     [+ATRIBUTE]                         [+NAME]                             raza                         [-NAME]                         [+TIPO]                             STRING                         [-TIPO]                     [-ATRIBUTE]                 [-ATRIBUTES]             [-TYPEUS]             [+TYPEUS]                 [+NAME]                     animal                 [-NAME]                 [+ATRIBUTES]                     [+ATRIBUTE]                         [+NAME]                             nombre                         [-NAME]                         [+TIPO]                             STRING                         [-TIPO]                     [-ATRIBUTE]                     [+ATRIBUTE]                         [+NAME]                             edad                         [-NAME]                         [+TIPO]                             int                         [-TIPO]                     [-ATRIBUTE]                     [+ATRIBUTE]                         [+NAME]                             raza                         [-NAME]                         [+TIPO]                             STRING                         [-TIPO]                     [-ATRIBUTE]                 [-ATRIBUTES]             [-TYPEUS]             [+TYPEUS]                 [+NAME]                     animal                 [-NAME]                 [+ATRIBUTES]                     [+ATRIBUTE]                         [+NAME]                             nombre                         [-NAME]                         [+TIPO]                             STRING                         [-TIPO]                     [-ATRIBUTE]                     [+ATRIBUTE]                         [+NAME]                             edad                         [-NAME]                         [+TIPO]                             int                         [-TIPO]                     [-ATRIBUTE]                     [+ATRIBUTE]                         [+NAME]                             raza                         [-NAME]                         [+TIPO]                             STRING                         [-TIPO]                     [-ATRIBUTE]                 [-ATRIBUTES]             [-TYPEUS]         [-TYPES]                       [+PROCEDURES]             [+PROCEDURE]                 [+NAME]                     Ordenar                 [-NAME]                 [+PARAMETERS]                     [+PARAMETER]                         [+NAME]                             perro                         [-NAME]                         [+TIPO]                             animal                         [-TIPO]                         [+AS]                             in                         [-AS]                     [-PARAMETER]                     [+PARAMETER]                         [+NAME]                             obedecio                         [-NAME]                         [+TIPO]                             boolean                         [-TIPO]                         [+AS]                             out                         [-AS]                     [-PARAMETER]                 [-PARAMETERS]             [-PROCEDURE]             [+PROCEDURE]                 [+NAME]                     Ordenar                 [-NAME]                 [+PARAMETERS]                     [+PARAMETER]                         [+NAME]                             perro                         [-NAME]                         [+TIPO]                             animal                         [-TIPO]                         [+AS]                             in                         [-AS]                     [-PARAMETER]                     [+PARAMETER]                         [+NAME]                             obedecio                         [-NAME]                         [+TIPO]                             boolean                         [-TIPO]                         [+AS]                             out                         [-AS]                     [-PARAMETER]                 [-PARAMETERS]             [-PROCEDURE]             [+PROCEDURE]                 [+NAME]                     Ordenar                 [-NAME]                 [+PARAMETERS]                     [+PARAMETER]                         [+NAME]                             perro                         [-NAME]                         [+TIPO]                             animal                         [-TIPO]                         [+AS]                             in                         [-AS]                     [-PARAMETER]                     [+PARAMETER]                         [+NAME]                             obedecio                         [-NAME]                         [+TIPO]                             boolean                         [-TIPO]                         [+AS]                             out                         [-AS]                     [-PARAMETER]                 [-PARAMETERS]             [-PROCEDURE]             [+PROCEDURE]                 [+NAME]                     Ordenar                 [-NAME]                 [+PARAMETERS]                     [+PARAMETER]                         [+NAME]                             perro                         [-NAME]                         [+TIPO]                             animal                         [-TIPO]                         [+AS]                             in                         [-AS]                     [-PARAMETER]                     [+PARAMETER]                         [+NAME]                             obedecio                         [-NAME]                         [+TIPO]                             boolean                         [-TIPO]                         [+AS]                             out                         [-AS]                     [-PARAMETER]                 [-PARAMETERS]             [-PROCEDURE]         [-PROCEDURES]     [-DATABASE]     [+DATABASE]         [+NAME]             base_no_1         [-NAME]         [+TABLES]             [+TABLE]                 [+NAME]                     tabla_1_base_1                 [-NAME]                 [+COLUMNS]                     [+COLUMN]                         [+NAME]                             col_1                         [-NAME]                         [+TIPO]                             INT                         [-TIPO]                         [+PK]                             TRUE                         [-PK]                     [-COLUMN]                     [+COLUMN]                         [+NAME]                             col_2                         [-NAME]                         [+TIPO]                             string                         [-TIPO]                         [+PK]                             false                         [-PK]                     [-COLUMN]                     [+COLUMN]                         [+NAME]                             col_3                         [-NAME]                         [+TIPO]                             date                         [-TIPO]                         [+PK]                             false                         [-PK]                     [-COLUMN]                 [-COLUMNS]             [-TABLE]             [+TABLE]                 [+NAME]                     tabla_1_base_1                 [-NAME]                 [+COLUMNS]                     [+COLUMN]                         [+NAME]                             col_1                         [-NAME]                         [+TIPO]                             INT                         [-TIPO]                         [+PK]                             TRUE                         [-PK]                     [-COLUMN]                     [+COLUMN]                         [+NAME]                             col_2                         [-NAME]                         [+TIPO]                             string                         [-TIPO]                         [+PK]                             false                         [-PK]                     [-COLUMN]                     [+COLUMN]                         [+NAME]                             col_3                         [-NAME]                         [+TIPO]                             date                         [-TIPO]                         [+PK]                             false                         [-PK]                     [-COLUMN]                 [-COLUMNS]             [-TABLE]             [+TABLE]                 [+NAME]                     tabla_1_base_1                 [-NAME]                 [+COLUMNS]                     [+COLUMN]                         [+NAME]                             col_1                         [-NAME]                         [+TIPO]                             INT                         [-TIPO]                         [+PK]                             TRUE                         [-PK]                     [-COLUMN]                     [+COLUMN]                         [+NAME]                             col_2                         [-NAME]                         [+TIPO]                             string                         [-TIPO]                         [+PK]                             false                         [-PK]                     [-COLUMN]                     [+COLUMN]                         [+NAME]                             col_3                         [-NAME]                         [+TIPO]                             date                         [-TIPO]                         [+PK]                             false                         [-PK]                     [-COLUMN]                 [-COLUMNS]             [-TABLE]                       [-TABLES]          [+TYPES]             [+TYPEUS]                 [+NAME]                     animal                 [-NAME]                 [+ATRIBUTES]                     [+ATRIBUTE]                         [+NAME]                             nombre                         [-NAME]                         [+TIPO]                             STRING                         [-TIPO]                     [-ATRIBUTE]                     [+ATRIBUTE]                         [+NAME]                             edad                         [-NAME]                         [+TIPO]                             int                         [-TIPO]                     [-ATRIBUTE]                     [+ATRIBUTE]                         [+NAME]                             raza                         [-NAME]                         [+TIPO]                             STRING                         [-TIPO]                     [-ATRIBUTE]                 [-ATRIBUTES]             [-TYPEUS]             [+TYPEUS]                 [+NAME]                     animal                 [-NAME]                 [+ATRIBUTES]                     [+ATRIBUTE]                         [+NAME]                             nombre                         [-NAME]                         [+TIPO]                             STRING                         [-TIPO]                     [-ATRIBUTE]                     [+ATRIBUTE]                         [+NAME]                             edad                         [-NAME]                         [+TIPO]                             int                         [-TIPO]                     [-ATRIBUTE]                     [+ATRIBUTE]                         [+NAME]                             raza                         [-NAME]                         [+TIPO]                             STRING                         [-TIPO]                     [-ATRIBUTE]                 [-ATRIBUTES]             [-TYPEUS]             [+TYPEUS]                 [+NAME]                     animal                 [-NAME]                 [+ATRIBUTES]                     [+ATRIBUTE]                         [+NAME]                             nombre                         [-NAME]                         [+TIPO]                             STRING                         [-TIPO]                     [-ATRIBUTE]                     [+ATRIBUTE]                         [+NAME]                             edad                         [-NAME]                         [+TIPO]                             int                         [-TIPO]                     [-ATRIBUTE]                     [+ATRIBUTE]                         [+NAME]                             raza                         [-NAME]                         [+TIPO]                             STRING                         [-TIPO]                     [-ATRIBUTE]                 [-ATRIBUTES]             [-TYPEUS]         [-TYPES]                       [+PROCEDURES]             [+PROCEDURE]                 [+NAME]                     Ordenar                 [-NAME]                 [+PARAMETERS]                     [+PARAMETER]                         [+NAME]                             perro                         [-NAME]                         [+TIPO]                             animal                         [-TIPO]                         [+AS]                             in                         [-AS]                     [-PARAMETER]                     [+PARAMETER]                         [+NAME]                             obedecio                         [-NAME]                         [+TIPO]                             boolean                         [-TIPO]                         [+AS]                             out                         [-AS]                     [-PARAMETER]                 [-PARAMETERS]             [-PROCEDURE]             [+PROCEDURE]                 [+NAME]                     Ordenar                 [-NAME]                 [+PARAMETERS]                     [+PARAMETER]                         [+NAME]                             perro                         [-NAME]                         [+TIPO]                             animal                         [-TIPO]                         [+AS]                             in                         [-AS]                     [-PARAMETER]                     [+PARAMETER]                         [+NAME]                             obedecio                         [-NAME]                         [+TIPO]                             boolean                         [-TIPO]                         [+AS]                             out                         [-AS]                     [-PARAMETER]                 [-PARAMETERS]             [-PROCEDURE]             [+PROCEDURE]                 [+NAME]                     Ordenar                 [-NAME]                 [+PARAMETERS]                     [+PARAMETER]                         [+NAME]                             perro                         [-NAME]                         [+TIPO]                             animal                         [-TIPO]                         [+AS]                             in                         [-AS]                     [-PARAMETER]                     [+PARAMETER]                         [+NAME]                             obedecio                         [-NAME]                         [+TIPO]                             boolean                         [-TIPO]                         [+AS]                             out                         [-AS]                     [-PARAMETER]                 [-PARAMETERS]             [-PROCEDURE]             [+PROCEDURE]                 [+NAME]                     Ordenar                 [-NAME]                 [+PARAMETERS]                     [+PARAMETER]                         [+NAME]                             perro                         [-NAME]                         [+TIPO]                             animal                         [-TIPO]                         [+AS]                             in                         [-AS]                     [-PARAMETER]                     [+PARAMETER]                         [+NAME]                             obedecio                         [-NAME]                         [+TIPO]                             boolean                         [-TIPO]                         [+AS]                             out                         [-AS]                     [-PARAMETER]                 [-PARAMETERS]             [-PROCEDURE]         [-PROCEDURES]     [-DATABASE]     [+DATABASE]         [+NAME]             base_no_1         [-NAME]         [+TABLES]             [+TABLE]                 [+NAME]                     tabla_1_base_1                 [-NAME]                 [+COLUMNS]                     [+COLUMN]                         [+NAME]                             col_1                         [-NAME]                         [+TIPO]                             INT                         [-TIPO]                         [+PK]                             TRUE                         [-PK]                     [-COLUMN]                     [+COLUMN]                         [+NAME]                             col_2                         [-NAME]                         [+TIPO]                             string                         [-TIPO]                         [+PK]                             false                         [-PK]                     [-COLUMN]                     [+COLUMN]                         [+NAME]                             col_3                         [-NAME]                         [+TIPO]                             date                         [-TIPO]                         [+PK]                             false                         [-PK]                     [-COLUMN]                 [-COLUMNS]             [-TABLE]             [+TABLE]                 [+NAME]                     tabla_1_base_1                 [-NAME]                 [+COLUMNS]                     [+COLUMN]                         [+NAME]                             col_1                         [-NAME]                         [+TIPO]                             INT                         [-TIPO]                         [+PK]                             TRUE                         [-PK]                     [-COLUMN]                     [+COLUMN]                         [+NAME]                             col_2                         [-NAME]                         [+TIPO]                             string                         [-TIPO]                         [+PK]                             false                         [-PK]                     [-COLUMN]                     [+COLUMN]                         [+NAME]                             col_3                         [-NAME]                         [+TIPO]                             date                         [-TIPO]                         [+PK]                             false                         [-PK]                     [-COLUMN]                 [-COLUMNS]             [-TABLE]             [+TABLE]                 [+NAME]                     tabla_1_base_1                 [-NAME]                 [+COLUMNS]                     [+COLUMN]                         [+NAME]                             col_1                         [-NAME]                         [+TIPO]                             INT                         [-TIPO]                         [+PK]                             TRUE                         [-PK]                     [-COLUMN]                     [+COLUMN]                         [+NAME]                             col_2                         [-NAME]                         [+TIPO]                             string                         [-TIPO]                         [+PK]                             false                         [-PK]                     [-COLUMN]                     [+COLUMN]                         [+NAME]                             col_3                         [-NAME]                         [+TIPO]                             date                         [-TIPO]                         [+PK]                             false                         [-PK]                     [-COLUMN]                 [-COLUMNS]             [-TABLE]                       [-TABLES]          [+TYPES]             [+TYPEUS]                 [+NAME]                     animal                 [-NAME]                 [+ATRIBUTES]                     [+ATRIBUTE]                         [+NAME]                             nombre                         [-NAME]                         [+TIPO]                             STRING                         [-TIPO]                     [-ATRIBUTE]                     [+ATRIBUTE]                         [+NAME]                             edad                         [-NAME]                         [+TIPO]                             int                         [-TIPO]                     [-ATRIBUTE]                     [+ATRIBUTE]                         [+NAME]                             raza                         [-NAME]                         [+TIPO]                             STRING                         [-TIPO]                     [-ATRIBUTE]                 [-ATRIBUTES]             [-TYPEUS]             [+TYPEUS]                 [+NAME]                     animal                 [-NAME]                 [+ATRIBUTES]                     [+ATRIBUTE]                         [+NAME]                             nombre                         [-NAME]                         [+TIPO]                             STRING                         [-TIPO]                     [-ATRIBUTE]                     [+ATRIBUTE]                         [+NAME]                             edad                         [-NAME]                         [+TIPO]                             int                         [-TIPO]                     [-ATRIBUTE]                     [+ATRIBUTE]                         [+NAME]                             raza                         [-NAME]                         [+TIPO]                             STRING                         [-TIPO]                     [-ATRIBUTE]                 [-ATRIBUTES]             [-TYPEUS]             [+TYPEUS]                 [+NAME]                     animal                 [-NAME]                 [+ATRIBUTES]                     [+ATRIBUTE]                         [+NAME]                             nombre                         [-NAME]                         [+TIPO]                             STRING                         [-TIPO]                     [-ATRIBUTE]                     [+ATRIBUTE]                         [+NAME]                             edad                         [-NAME]                         [+TIPO]                             int                         [-TIPO]                     [-ATRIBUTE]                     [+ATRIBUTE]                         [+NAME]                             raza                         [-NAME]                         [+TIPO]                             STRING                         [-TIPO]                     [-ATRIBUTE]                 [-ATRIBUTES]             [-TYPEUS]         [-TYPES]                       [+PROCEDURES]             [+PROCEDURE]                 [+NAME]                     Ordenar                 [-NAME]                 [+PARAMETERS]                     [+PARAMETER]                         [+NAME]                             perro                         [-NAME]                         [+TIPO]                             animal                         [-TIPO]                         [+AS]                             in                         [-AS]                     [-PARAMETER]                     [+PARAMETER]                         [+NAME]                             obedecio                         [-NAME]                         [+TIPO]                             boolean                         [-TIPO]                         [+AS]                             out                         [-AS]                     [-PARAMETER]                 [-PARAMETERS]             [-PROCEDURE]             [+PROCEDURE]                 [+NAME]                     Ordenar                 [-NAME]                 [+PARAMETERS]                     [+PARAMETER]                         [+NAME]                             perro                         [-NAME]                         [+TIPO]                             animal                         [-TIPO]                         [+AS]                             in                         [-AS]                     [-PARAMETER]                     [+PARAMETER]                         [+NAME]                             obedecio                         [-NAME]                         [+TIPO]                             boolean                         [-TIPO]                         [+AS]                             out                         [-AS]                     [-PARAMETER]                 [-PARAMETERS]             [-PROCEDURE]             [+PROCEDURE]                 [+NAME]                     Ordenar                 [-NAME]                 [+PARAMETERS]                     [+PARAMETER]                         [+NAME]                             perro                         [-NAME]                         [+TIPO]                             animal                         [-TIPO]                         [+AS]                             in                         [-AS]                     [-PARAMETER]                     [+PARAMETER]                         [+NAME]                             obedecio                         [-NAME]                         [+TIPO]                             boolean                         [-TIPO]                         [+AS]                             out                         [-AS]                     [-PARAMETER]                 [-PARAMETERS]             [-PROCEDURE]             [+PROCEDURE]                 [+NAME]                     Ordenar                 [-NAME]                 [+PARAMETERS]                     [+PARAMETER]                         [+NAME]                             perro                         [-NAME]                         [+TIPO]                             animal                         [-TIPO]                         [+AS]                             in                         [-AS]                     [-PARAMETER]                     [+PARAMETER]                         [+NAME]                             obedecio                         [-NAME]                         [+TIPO]                             boolean                         [-TIPO]                         [+AS]                             out                         [-AS]                     [-PARAMETER]                 [-PARAMETERS]             [-PROCEDURE]         [-PROCEDURES]     [-DATABASE] [-DATABASES]"));
        }
    }
}