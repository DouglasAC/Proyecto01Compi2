'use strict';

goog.require('Blockly.JavaScript');


Blockly.JavaScript['use'] = function (block) {
  var value_use = Blockly.JavaScript.valueToCode(block, 'Use', Blockly.JavaScript.ORDER_NONE);
  // TODO: Assemble JavaScript into code variable.
  var code = "USE " + value_use + ';\n';
  return code;
};

Blockly.JavaScript['select'] = function (block) {
  var value_select = Blockly.JavaScript.valueToCode(block, 'Select', Blockly.JavaScript.ORDER_NONE);
  var value_from = Blockly.JavaScript.valueToCode(block, 'From', Blockly.JavaScript.ORDER_NONE);
  var value_where = Blockly.JavaScript.valueToCode(block, 'Where', Blockly.JavaScript.ORDER_NONE);
  var value_order_by = Blockly.JavaScript.valueToCode(block, 'Order_by', Blockly.JavaScript.ORDER_NONE);
  var value_limit = Blockly.JavaScript.valueToCode(block, 'Limit', Blockly.JavaScript.ORDER_NONE);
  // TODO: Assemble JavaScript into code variable.
  var code = 'SELECT ' + value_select + ' FROM ' + value_from;
  if (value_where != "") {
    code += ' WHERE ' + value_where;
  }
  if (value_order_by != "") {
    code += ' ORDER BY ' + value_order_by;
  }
  if (value_limit != "") {
    code += ' LIMIT ' + value_limit;
  }

  code += ';\n';
  return code;
};

Blockly.JavaScript['update'] = function (block) {
  var value_update = Blockly.JavaScript.valueToCode(block, 'Update', Blockly.JavaScript.ORDER_NONE);
  var value_set = Blockly.JavaScript.valueToCode(block, 'Set', Blockly.JavaScript.ORDER_NONE);
  var value_where = Blockly.JavaScript.valueToCode(block, 'Where', Blockly.JavaScript.ORDER_NONE);
  // TODO: Assemble JavaScript into code variable.
  var code = 'UPDATE ' + value_update + ' SET ' + value_set;
  if (value_where != "") {
    code += ' WHERE ' + value_where;
  }
  code += ';\n';
  return code;
};

Blockly.JavaScript['delete'] = function (block) {
  var value_delete = Blockly.JavaScript.valueToCode(block, 'Delete', Blockly.JavaScript.ORDER_NONE);
  var value_where = Blockly.JavaScript.valueToCode(block, 'Where', Blockly.JavaScript.ORDER_NONE);
  // TODO: Assemble JavaScript into code variable.
  var code = 'DELETE FROM ' + value_delete
  if (value_where != "") {
    code += ' WHERE ' + value_where;
  }
  code += ';\n';
  return code;
};

Blockly.JavaScript['insert'] = function (block) {
  var value_tabla = Blockly.JavaScript.valueToCode(block, 'tabla', Blockly.JavaScript.ORDER_NONE);
  var value_valores = Blockly.JavaScript.valueToCode(block, 'valores', Blockly.JavaScript.ORDER_NONE);
  // TODO: Assemble JavaScript into code variable.
  var code = 'INSERT INTO ' + value_tabla + ' VALUES ( ' + value_valores + ' );\n';
  return code;
};

Blockly.JavaScript['insert_esp'] = function (block) {
  var value_insert = Blockly.JavaScript.valueToCode(block, 'insert', Blockly.JavaScript.ORDER_NONE);
  var value_values_esp = Blockly.JavaScript.valueToCode(block, 'values_esp', Blockly.JavaScript.ORDER_NONE);
  var value_values = Blockly.JavaScript.valueToCode(block, 'values', Blockly.JavaScript.ORDER_NONE);
  // TODO: Assemble JavaScript into code variable.
  var code = 'INSERT INTO ' + value_insert + ' ( ' + value_values_esp + ' ) VALUES (' + value_values + ');\n';
  return code;
};



/// ----------------------- Atributos -----------------------

Blockly.JavaScript['atributos'] = function (block) {
  var text_valor = block.getFieldValue('valor');
  var value_texto = Blockly.JavaScript.valueToCode(block, 'texto', Blockly.JavaScript.ORDER_NONE);
  // TODO: Assemble JavaScript into code variable.
  var code = text_valor;
  if (value_texto != "") {
    code += ' ' + value_texto;
  }
  // TODO: Change ORDER_NONE to the correct strength.
  return [code, Blockly.JavaScript.ORDER_NONE];
};

Blockly.JavaScript['comodin'] = function (block) {
  // TODO: Assemble JavaScript into code variable.
  var code = '*';
  // TODO: Change ORDER_NONE to the correct strength.
  return [code, Blockly.JavaScript.ORDER_NONE];
};

Blockly.JavaScript['cierra'] = function (block) {
  var text_texto = block.getFieldValue('texto');
  // TODO: Assemble JavaScript into code variable.
  var code = text_texto;
  // TODO: Change ORDER_NONE to the correct strength.
  return [code, Blockly.JavaScript.ORDER_NONE];
};



///---------------- operaciones -------------


Blockly.JavaScript['inicio_bool'] = function (block) {
  var value_op2 = Blockly.JavaScript.valueToCode(block, 'op2', Blockly.JavaScript.ORDER_NONE);
  var dropdown_operador = block.getFieldValue('operador');
  var value_ope1 = Blockly.JavaScript.valueToCode(block, 'ope1', Blockly.JavaScript.ORDER_NONE);
  // TODO: Assemble JavaScript into code variable.
  var code = value_op2 + ' ' + dropdown_operador + ' ' + value_ope1;
  // TODO: Change ORDER_NONE to the correct strength.
  return [code, Blockly.JavaScript.ORDER_NONE];
};

Blockly.JavaScript['not'] = function (block) {
  var value_name = Blockly.JavaScript.valueToCode(block, 'NAME', Blockly.JavaScript.ORDER_NONE);
  // TODO: Assemble JavaScript into code variable.
  var code = '!( ' + value_name + ' ) ';
  // TODO: Change ORDER_NONE to the correct strength.
  return [code, Blockly.JavaScript.ORDER_NONE];
};

Blockly.JavaScript['aritmeticas'] = function (block) {
  var value_op1 = Blockly.JavaScript.valueToCode(block, 'op1', Blockly.JavaScript.ORDER_NONE);
  var dropdown_operador = block.getFieldValue('operador');
  var value_op2 = Blockly.JavaScript.valueToCode(block, 'op2', Blockly.JavaScript.ORDER_NONE);
  // TODO: Assemble JavaScript into code variable.
  var code = value_op1 + ' ' + dropdown_operador + ' ' + value_op2;
  // TODO: Change ORDER_NONE to the correct strength.
  return [code, Blockly.JavaScript.ORDER_NONE];
};

Blockly.JavaScript['unitarias'] = function (block) {
  var value_opu = Blockly.JavaScript.valueToCode(block, 'opU', Blockly.JavaScript.ORDER_NONE);
  var dropdown_operador = block.getFieldValue('OPERADOR');
  // TODO: Assemble JavaScript into code variable.
  var code = value_opu + '' + dropdown_operador;
  // TODO: Change ORDER_NONE to the correct strength.
  return [code, Blockly.JavaScript.ORDER_NONE];
};

Blockly.JavaScript['relacionales'] = function (block) {
  var value_op1 = Blockly.JavaScript.valueToCode(block, 'op1', Blockly.JavaScript.ORDER_NONE);
  var dropdown_ope = block.getFieldValue('ope');
  var value_op2 = Blockly.JavaScript.valueToCode(block, 'op2', Blockly.JavaScript.ORDER_NONE);
  // TODO: Assemble JavaScript into code variable.
  var code = value_op1 + ' ' + dropdown_ope + ' ' + value_op2;
  // TODO: Change ORDER_NONE to the correct strength.
  return [code, Blockly.JavaScript.ORDER_NONE];
};

//----------------------- VALORES -----------------------------------------------

Blockly.JavaScript['numero'] = function (block) {
  var number_valor = block.getFieldValue('valor');
  // TODO: Assemble JavaScript into code variable.
  var code = number_valor + '';
  // TODO: Change ORDER_NONE to the correct strength.
  return [code, Blockly.JavaScript.ORDER_NONE];
};

Blockly.JavaScript['bool'] = function (block) {
  var dropdown_valor = block.getFieldValue('valor');
  // TODO: Assemble JavaScript into code variable.
  var code = dropdown_valor + '';
  // TODO: Change ORDER_NONE to the correct strength.
  return [code, Blockly.JavaScript.ORDER_NONE];
};

Blockly.JavaScript['texto'] = function (block) {
  var text_valor = block.getFieldValue('valor');
  // TODO: Assemble JavaScript into code variable.
  var code = text_valor + '';
  // TODO: Change ORDER_NONE to the correct strength.
  return [code, Blockly.JavaScript.ORDER_NONE];
};

Blockly.JavaScript['fecha'] = function (block) {
  var number_year = block.getFieldValue('year');
  var number_month = block.getFieldValue('month');
  var number_day = block.getFieldValue('day');
  // TODO: Assemble JavaScript into code variable.
  var code = number_year + '-' + number_month + '-' + number_day;
  // TODO: Change ORDER_NONE to the correct strength.
  return [code, Blockly.JavaScript.ORDER_NONE];
};

Blockly.JavaScript['tiemp'] = function (block) {
  var number_horas = block.getFieldValue('horas');
  var number_minutos = block.getFieldValue('minutos');
  var number_segundos = block.getFieldValue('segundos');
  // TODO: Assemble JavaScript into code variable.
  var code = number_horas + ':' + number_minutos + ':' + number_segundos;
  // TODO: Change ORDER_NONE to the correct strength.
  return [code, Blockly.JavaScript.ORDER_NONE];
};




///------------------------------- VARIABLES --------------------

Blockly.JavaScript['declaracion'] = function (block) {
  var dropdown_tipo = block.getFieldValue('tipo');
  var value_variable = Blockly.JavaScript.valueToCode(block, 'variable', Blockly.JavaScript.ORDER_NONE);
  // TODO: Assemble JavaScript into code variable.
  var code = dropdown_tipo + ' ' + value_variable + ';\n';
  return code;
};

Blockly.JavaScript['declaracion_asignacion'] = function (block) {
  var dropdown_tipo = block.getFieldValue('tipo');
  var value_tipo = Blockly.JavaScript.valueToCode(block, 'tipo', Blockly.JavaScript.ORDER_NONE);
  var value_expresion = Blockly.JavaScript.valueToCode(block, 'expresion', Blockly.JavaScript.ORDER_NONE);
  // TODO: Assemble JavaScript into code variable.
  var code = dropdown_tipo + ' ' + value_tipo + ' = ' + value_expresion + ';\n';
  return code;
};

Blockly.JavaScript['asignacion'] = function (block) {
  var value_variable = Blockly.JavaScript.valueToCode(block, 'variable', Blockly.JavaScript.ORDER_NONE);
  var value_expresion = Blockly.JavaScript.valueToCode(block, 'expresion', Blockly.JavaScript.ORDER_NONE);
  // TODO: Assemble JavaScript into code variable.
  var code = value_variable + ' = ' + value_expresion + ';\n';
  return code;
};

Blockly.JavaScript['declaracion_asignacion_2'] = function (block) {
  var dropdown_variable = block.getFieldValue('variable');
  var value_variable = Blockly.JavaScript.valueToCode(block, 'variable', Blockly.JavaScript.ORDER_NONE);
  var value_name = Blockly.JavaScript.valueToCode(block, 'NAME', Blockly.JavaScript.ORDER_NONE);
  // TODO: Assemble JavaScript into code variable.
  var code = dropdown_variable + ' ' + value_variable + ' = ' + value_name;
  // TODO: Change ORDER_NONE to the correct strength.
  return [code, Blockly.JavaScript.ORDER_NONE];
};

Blockly.JavaScript['asignacion_2'] = function (block) {
  var value_variable = Blockly.JavaScript.valueToCode(block, 'variable', Blockly.JavaScript.ORDER_NONE);
  var value_valor = Blockly.JavaScript.valueToCode(block, 'valor', Blockly.JavaScript.ORDER_NONE);
  // TODO: Assemble JavaScript into code variable.
  var code = value_variable + ' = ' + value_valor;
  // TODO: Change ORDER_NONE to the correct strength.
  return [code, Blockly.JavaScript.ORDER_NONE];
};



//--------------------------------- control



Blockly.JavaScript['if'] = function (block) {
  var value_condicion = Blockly.JavaScript.valueToCode(block, 'condicion', Blockly.JavaScript.ORDER_NONE);
  var statements_acciones = Blockly.JavaScript.statementToCode(block, 'acciones');
  // TODO: Assemble JavaScript into code variable.
  var code = 'if (' + value_condicion + ' ) {\n' + statements_acciones + '\n}\n';
  return code;
};

Blockly.JavaScript['else'] = function (block) {
  var statements_acciones = Blockly.JavaScript.statementToCode(block, 'acciones');
  // TODO: Assemble JavaScript into code variable.
  var code = 'else {\n' + statements_acciones + '\n}\n';
  return code;
};

Blockly.JavaScript['else_if'] = function (block) {
  var value_condicion = Blockly.JavaScript.valueToCode(block, 'condicion', Blockly.JavaScript.ORDER_NONE);
  var statements_acciones = Blockly.JavaScript.statementToCode(block, 'acciones');
  // TODO: Assemble JavaScript into code variable.
  var code = 'else if ( ' + value_condicion + ' ) {\n' + statements_acciones + '\n}\n';
  return code;
};

Blockly.JavaScript['switch'] = function (block) {
  var value_switch = Blockly.JavaScript.valueToCode(block, 'switch', Blockly.JavaScript.ORDER_NONE);
  var statements_name = Blockly.JavaScript.statementToCode(block, 'NAME');
  // TODO: Assemble JavaScript into code variable.
  var code = 'switch ( ' + value_switch + ' ) {\n' + statements_name + '\n}\n';
  return code;
};

Blockly.JavaScript['case'] = function (block) {
  var value_case = Blockly.JavaScript.valueToCode(block, 'case', Blockly.JavaScript.ORDER_NONE);
  var statements_name = Blockly.JavaScript.statementToCode(block, 'NAME');
  // TODO: Assemble JavaScript into code variable.
  var code = 'case ' + value_case + ': {\n' + statements_name + '\n}\n';
  return code;
};

Blockly.JavaScript['default'] = function (block) {
  var statements_default = Blockly.JavaScript.statementToCode(block, 'default');
  // TODO: Assemble JavaScript into code variable.
  var code = 'default:\n' + statements_default + '\n}\n';
  return code;
};

Blockly.JavaScript['detener'] = function (block) {
  // TODO: Assemble JavaScript into code variable.
  var code = 'break;\n';
  return code;
};


///--------------------- ciclos-------------

Blockly.JavaScript['while'] = function (block) {
  var value_condicion = Blockly.JavaScript.valueToCode(block, 'condicion', Blockly.JavaScript.ORDER_NONE);
  var statements_acciones = Blockly.JavaScript.statementToCode(block, 'acciones');
  // TODO: Assemble JavaScript into code variable.
  var code = 'while ( ' + value_condicion + ' ) {\n' + statements_acciones + '\n}\n';
  return code;
};

Blockly.JavaScript['do_while'] = function (block) {
  var statements_acciones = Blockly.JavaScript.statementToCode(block, 'acciones');
  var value_condicion = Blockly.JavaScript.valueToCode(block, 'condicion', Blockly.JavaScript.ORDER_NONE);
  // TODO: Assemble JavaScript into code variable.
  var code = 'do {\n' + statements_acciones + '\n} while (' + value_condicion + ' );\n';
  return code;
};

Blockly.JavaScript['for'] = function (block) {
  var value_inicializacion = Blockly.JavaScript.valueToCode(block, 'inicializacion', Blockly.JavaScript.ORDER_NONE);
  var value_condicion = Blockly.JavaScript.valueToCode(block, 'condicion', Blockly.JavaScript.ORDER_NONE);
  var value_actualizaccion = Blockly.JavaScript.valueToCode(block, 'actualizaccion', Blockly.JavaScript.ORDER_NONE);
  var statements_acciones = Blockly.JavaScript.statementToCode(block, 'acciones');
  // TODO: Assemble JavaScript into code variable.
  var code = 'for ( ' + value_inicializacion + '; ' + value_condicion + '; ' + value_actualizaccion + ' ) {\n' + statements_acciones + '\n}\n';
  return code;
};

//---------------- lamadas, ++2 y --22

Blockly.JavaScript['llamada_funcion'] = function (block) {
  var value_funcion = Blockly.JavaScript.valueToCode(block, 'funcion', Blockly.JavaScript.ORDER_NONE);
  // TODO: Assemble JavaScript into code variable.
  var code = value_funcion + '()';
  // TODO: Change ORDER_NONE to the correct strength.
  return [code, Blockly.JavaScript.ORDER_NONE];
};

Blockly.JavaScript['llamda_funciones_2'] = function (block) {
  var value_funcion = Blockly.JavaScript.valueToCode(block, 'funcion', Blockly.JavaScript.ORDER_NONE);
  var value_parametros = Blockly.JavaScript.valueToCode(block, 'parametros', Blockly.JavaScript.ORDER_NONE);
  // TODO: Assemble JavaScript into code variable.
  var code = value_funcion + '( ' + value_parametros + ')';
  // TODO: Change ORDER_NONE to the correct strength.
  return [code, Blockly.JavaScript.ORDER_NONE];
};

Blockly.JavaScript['log'] = function (block) {
  var value_log = Blockly.JavaScript.valueToCode(block, 'log', Blockly.JavaScript.ORDER_NONE);
  // TODO: Assemble JavaScript into code variable.
  var code = 'log(' + value_log + ');\n';
  return code;
};

Blockly.JavaScript['llamada_proc'] = function (block) {
  var value_nomblre = Blockly.JavaScript.valueToCode(block, 'nomblre', Blockly.JavaScript.ORDER_NONE);
  // TODO: Assemble JavaScript into code variable.
  var code = 'call ' + value_nomblre + '()';
  // TODO: Change ORDER_NONE to the correct strength.
  return [code, Blockly.JavaScript.ORDER_NONE];
};

Blockly.JavaScript['llamada_proc_2'] = function (block) {
  var value_nombre = Blockly.JavaScript.valueToCode(block, 'nombre', Blockly.JavaScript.ORDER_NONE);
  var value_parametros = Blockly.JavaScript.valueToCode(block, 'parametros', Blockly.JavaScript.ORDER_NONE);
  // TODO: Assemble JavaScript into code variable.
  var code = 'call ' + value_nombre + '( ' + value_parametros + ' )';
  // TODO: Change ORDER_NONE to the correct strength.
  return [code, Blockly.JavaScript.ORDER_NONE];
};

Blockly.JavaScript['llamada_proc_3'] = function (block) {
  var value_nombre = Blockly.JavaScript.valueToCode(block, 'nombre', Blockly.JavaScript.ORDER_NONE);
  var value_parametros = Blockly.JavaScript.valueToCode(block, 'parametros', Blockly.JavaScript.ORDER_NONE);
  // TODO: Assemble JavaScript into code variable.
  var code = 'call ' + value_nombre + '( ' + value_parametros + ');\n';
  return code;
};

Blockly.JavaScript['llamada_proc_4'] = function (block) {
  var value_nomblre = Blockly.JavaScript.valueToCode(block, 'nomblre', Blockly.JavaScript.ORDER_NONE);
  // TODO: Assemble JavaScript into code variable.
  var code = 'call ' + value_nomblre + '();\n';
  return code;
};

Blockly.JavaScript['incremento_decremento_2'] = function (block) {
  var value_variable = Blockly.JavaScript.valueToCode(block, 'variable', Blockly.JavaScript.ORDER_NONE);
  var dropdown_ope = block.getFieldValue('ope');
  // TODO: Assemble JavaScript into code variable.
  var code = value_variable + dropdown_ope + ';\n';
  return code;
};

Blockly.JavaScript['llamada_funcion_3'] = function (block) {
  var value_funcion = Blockly.JavaScript.valueToCode(block, 'funcion', Blockly.JavaScript.ORDER_NONE);
  // TODO: Assemble JavaScript into code variable.
  var code = value_funcion + '();\n';
  return code;
};

Blockly.JavaScript['llamda_funciones_4'] = function (block) {
  var value_funcion = Blockly.JavaScript.valueToCode(block, 'funcion', Blockly.JavaScript.ORDER_NONE);
  var value_parametros = Blockly.JavaScript.valueToCode(block, 'parametros', Blockly.JavaScript.ORDER_NONE);
  // TODO: Assemble JavaScript into code variable.
  var code = value_funcion + '(' + value_parametros + ');\n';
  return code;
};
