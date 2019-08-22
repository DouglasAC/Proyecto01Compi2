'use strict';

goog.require('Blockly.Blocks');
goog.require('Blockly');


Blockly.defineBlocksWithJsonArray([{
  "type": "use",
  "message0": "Use %1",
  "args0": [
    {
      "type": "input_value",
      "name": "Use"
    }
  ],
  "previousStatement": null,
  "nextStatement": null,
  "colour": 65,
  "tooltip": "",
  "helpUrl": ""
},
{
  "type": "select",
  "message0": "%1 %2 %3 %4 %5 %6 %7 %8 %9 %10",
  "args0": [
    {
      "type": "field_label_serializable",
      "name": "Select",
      "text": "Select"
    },
    {
      "type": "input_value",
      "name": "Select"
    },
    {
      "type": "field_label_serializable",
      "name": "From",
      "text": "From"
    },
    {
      "type": "input_value",
      "name": "From"
    },
    {
      "type": "field_label_serializable",
      "name": "where",
      "text": "Where"
    },
    {
      "type": "input_value",
      "name": "Where"
    },
    {
      "type": "field_label_serializable",
      "name": "Order_by",
      "text": "Order_By"
    },
    {
      "type": "input_value",
      "name": "Order_by"
    },
    {
      "type": "field_label_serializable",
      "name": "Limit",
      "text": "Limit"
    },
    {
      "type": "input_value",
      "name": "Limit"
    }
  ],
  "inputsInline": false,
  "previousStatement": null,
  "nextStatement": null,
  "colour": 65,
  "tooltip": "",
  "helpUrl": ""
},
{
  "type": "update",
  "message0": "%1 %2 %3 %4 %5 %6",
  "args0": [
    {
      "type": "field_label_serializable",
      "name": "Update",
      "text": "Update"
    },
    {
      "type": "input_value",
      "name": "Update"
    },
    {
      "type": "field_label_serializable",
      "name": "Set",
      "text": "Set"
    },
    {
      "type": "input_value",
      "name": "Set"
    },
    {
      "type": "field_label_serializable",
      "name": "Where",
      "text": "Where"
    },
    {
      "type": "input_value",
      "name": "Where"
    }
  ],
  "previousStatement": null,
  "nextStatement": null,
  "colour": 65,
  "tooltip": "",
  "helpUrl": ""
},
{
  "type": "delete",
  "message0": "%1 %2 %3 %4",
  "args0": [
    {
      "type": "field_label_serializable",
      "name": "Delete",
      "text": "Delete From"
    },
    {
      "type": "input_value",
      "name": "Delete"
    },
    {
      "type": "field_label_serializable",
      "name": "Where",
      "text": "Where"
    },
    {
      "type": "input_value",
      "name": "Where"
    }
  ],
  "previousStatement": null,
  "nextStatement": null,
  "colour": 65,
  "tooltip": "",
  "helpUrl": ""
},
{
  "type": "insert",
  "message0": "INSERT INTO %1 VALUES %2 %3",
  "args0": [
    {
      "type": "input_value",
      "name": "tabla"
    },
    {
      "type": "input_dummy"
    },
    {
      "type": "input_value",
      "name": "valores"
    }
  ],
  "previousStatement": null,
  "nextStatement": null,
  "colour": 65,
  "tooltip": "",
  "helpUrl": ""
},
{
  "type": "insert_esp",
  "message0": "INSERT INTO %1 ( %2 ) VALUES  %3 %4",
  "args0": [
    {
      "type": "input_value",
      "name": "insert"
    },
    {
      "type": "input_value",
      "name": "values_esp"
    },
    {
      "type": "input_dummy"
    },
    {
      "type": "input_value",
      "name": "values"
    }
  ],
  "previousStatement": null,
  "nextStatement": null,
  "colour": 65,
  "tooltip": "",
  "helpUrl": ""
},
{
  "type": "atributos",
  "message0": "%1 %2",
  "args0": [
    {
      "type": "field_input",
      "name": "valor",
      "text": ""
    },
    {
      "type": "input_value",
      "name": "texto",
      "align": "CENTRE"
    }
  ],
  "output": null,
  "colour": 120,
  "tooltip": "",
  "helpUrl": ""
},
{
  "type": "comodin",
  "message0": "*",
  "output": null,
  "colour": 120,
  "tooltip": "",
  "helpUrl": ""
},
{
  "type": "cierra",
  "message0": "%1",
  "args0": [
    {
      "type": "field_input",
      "name": "texto",
      "text": ""
    }
  ],
  "output": null,
  "colour": 120,
  "tooltip": "",
  "helpUrl": ""
},/////----operadores
{
  "type": "inicio_bool",
  "message0": "%1 %2 %3 %4",
  "args0": [
    {
      "type": "input_value",
      "name": "op2"
    },
    {
      "type": "field_dropdown",
      "name": "operador",
      "options": [
        [
          "||",
          "||"
        ],
        [
          "&&",
          "&&"
        ],
        [
          "^",
          "^"
        ]
      ]
    },
    {
      "type": "input_value",
      "name": "ope1"
    },
    {
      "type": "input_dummy"
    }
  ],
  "output": null,
  "colour": 260,
  "tooltip": "",
  "helpUrl": ""
},
{
  "type": "not",
  "message0": "! %1",
  "args0": [
    {
      "type": "input_value",
      "name": "NAME"
    }
  ],
  "output": null,
  "colour": 260,
  "tooltip": "",
  "helpUrl": ""
},
{
  "type": "aritmeticas",
  "message0": "%1 %2 %3 %4",
  "args0": [
    {
      "type": "input_value",
      "name": "op1"
    },
    {
      "type": "field_dropdown",
      "name": "operador",
      "options": [
        [
          "+",
          "+"
        ],
        [
          "-",
          "-"
        ],
        [
          "*",
          "*"
        ],
        [
          "/",
          "/"
        ],
        [
          "**",
          "**"
        ],
        [
          "%",
          "%"
        ]
      ]
    },
    {
      "type": "input_dummy"
    },
    {
      "type": "input_value",
      "name": "op2"
    }
  ],
  "output": null,
  "colour": 260,
  "tooltip": "",
  "helpUrl": ""
},
{
  "type": "unitarias",
  "message0": "%1 %2",
  "args0": [
    {
      "type": "input_value",
      "name": "opU"
    },
    {
      "type": "field_dropdown",
      "name": "OPERADOR",
      "options": [
        [
          "++",
          "++"
        ],
        [
          "--",
          "--"
        ]
      ]
    }
  ],
  "output": null,
  "colour": 260,
  "tooltip": "",
  "helpUrl": ""
},
{
  "type": "relacionales",
  "message0": "%1 %2 %3 %4",
  "args0": [
    {
      "type": "input_value",
      "name": "op1"
    },
    {
      "type": "field_dropdown",
      "name": "ope",
      "options": [
        [
          "<",
          "<"
        ],
        [
          ">",
          ">"
        ],
        [
          "==",
          "=="
        ],
        [
          ">=",
          ">="
        ],
        [
          "<=",
          "<="
        ],
        [
          "!=",
          "!="
        ]
      ]
    },
    {
      "type": "input_dummy"
    },
    {
      "type": "input_value",
      "name": "op2"
    }
  ],
  "output": null,
  "colour": 260,
  "tooltip": "",
  "helpUrl": ""
  },
//-------------------------- valores ------------------
 {
  "type": "numero",
  "message0": "%1",
  "args0": [
    {
      "type": "field_number",
      "name": "valor",
      "value": 0
    }
  ],
  "output": null,
  "colour": 330,
  "tooltip": "",
  "helpUrl": ""
},
{
  "type": "bool",
  "message0": "%1",
  "args0": [
    {
      "type": "field_dropdown",
      "name": "valor",
      "options": [
        [
          "true",
          "true"
        ],
        [
          "false",
          "false"
        ]
      ]
    }
  ],
  "output": null,
  "colour": 330,
  "tooltip": "",
  "helpUrl": ""
},
{
  "type": "texto",
  "message0": "%1",
  "args0": [
    {
      "type": "field_input",
      "name": "valor",
      "text": ""
    }
  ],
  "output": null,
  "colour": 330,
  "tooltip": "",
  "helpUrl": ""
},
{
  "type": "fecha",
  "message0": "%1 - %2 - %3",
  "args0": [
    {
      "type": "field_number",
      "name": "year",
      "value": 0
    },
    {
      "type": "field_number",
      "name": "month",
      "value": 0,
      "min": 1,
      "max": 12
    },
    {
      "type": "field_number",
      "name": "day",
      "value": 0,
      "min": 1,
      "max": 31
    }
  ],
  "output": null,
  "colour": 330,
  "tooltip": "",
  "helpUrl": ""
},
{
  "type": "tiemp",
  "message0": "%1 : %2 : %3",
  "args0": [
    {
      "type": "field_number",
      "name": "horas",
      "value": 0,
      "min": 0,
      "max": 24
    },
    {
      "type": "field_number",
      "name": "minutos",
      "value": 0,
      "min": 0,
      "max": 59
    },
    {
      "type": "field_number",
      "name": "segundos",
      "value": 0,
      "min": 0,
      "max": 59
    }
  ],
  "output": null,
  "colour": 330,
  "tooltip": "",
  "helpUrl": ""
  },//------------------variables
  {
    "type": "declaracion",
    "message0": "%1 %2 %3",
    "args0": [
      {
        "type": "field_dropdown",
        "name": "tipo",
        "options": [
          [
            "int",
            "int"
          ],
          [
            "double",
            "double"
          ],
          [
            "string",
            "string"
          ],
          [
            "boolean",
            "boolean"
          ],
          [
            "date",
            "date"
          ],
          [
            "time",
            "time"
          ]
        ]
      },
      {
        "type": "input_value",
        "name": "variable"
      },
      {
        "type": "input_dummy"
      }
    ],
    "previousStatement": null,
    "nextStatement": null,
    "colour": 20,
    "tooltip": "",
    "helpUrl": ""
  },
  {
    "type": "declaracion_asignacion",
    "message0": "%1 %2 = %3 %4",
    "args0": [
      {
        "type": "field_dropdown",
        "name": "tipo",
        "options": [
          [
            "int",
            "int"
          ],
          [
            "double",
            "double"
          ],
          [
            "string",
            "string"
          ],
          [
            "boolean",
            "boolean"
          ],
          [
            "time",
            "time"
          ],
          [
            "date",
            "date"
          ]
        ]
      },
      {
        "type": "input_value",
        "name": "tipo"
      },
      {
        "type": "input_dummy"
      },
      {
        "type": "input_value",
        "name": "expresion"
      }
    ],
    "previousStatement": null,
    "nextStatement": null,
    "colour": 20,
    "tooltip": "",
    "helpUrl": ""
  },
  {
    "type": "asignacion",
    "message0": "Asignacion %1 = %2 %3",
    "args0": [
      {
        "type": "input_value",
        "name": "variable"
      },
      {
        "type": "input_dummy"
      },
      {
        "type": "input_value",
        "name": "expresion"
      }
    ],
    "previousStatement": null,
    "nextStatement": null,
    "colour": 20,
    "tooltip": "",
    "helpUrl": ""
  },
  {
    "type": "declaracion_asignacion_2",
    "message0": "%1 %2 = %3 %4",
    "args0": [
      {
        "type": "field_dropdown",
        "name": "variable",
        "options": [
          [
            "int",
            "int"
          ],
          [
            "double",
            "double"
          ],
          [
            "string",
            "string"
          ],
          [
            "boolean",
            "boolean"
          ],
          [
            "date",
            "date"
          ],
          [
            "time",
            "time"
          ]
        ]
      },
      {
        "type": "input_value",
        "name": "variable"
      },
      {
        "type": "input_dummy"
      },
      {
        "type": "input_value",
        "name": "NAME"
      }
    ],
    "output": null,
    "colour": 20,
    "tooltip": "",
    "helpUrl": ""
  },
  {
    "type": "asignacion_2",
    "message0": "Asignacion %1 = %2 %3",
    "args0": [
      {
        "type": "input_value",
        "name": "variable"
      },
      {
        "type": "input_dummy"
      },
      {
        "type": "input_value",
        "name": "valor"
      }
    ],
    "output": null,
    "colour": 20,
    "tooltip": "",
    "helpUrl": ""
  }, //---------------------- control -------------------------
  {
    "type": "if",
    "message0": "if %1 sentencias %2",
    "args0": [
      {
        "type": "input_value",
        "name": "condicion"
      },
      {
        "type": "input_statement",
        "name": "acciones"
      }
    ],
    "previousStatement": null,
    "nextStatement": null,
    "colour": 0,
    "tooltip": "",
    "helpUrl": ""
  },
  {
    "type": "else",
    "message0": "else %1",
    "args0": [
      {
        "type": "input_statement",
        "name": "acciones"
      }
    ],
    "previousStatement": null,
    "nextStatement": null,
    "colour": 0,
    "tooltip": "",
    "helpUrl": ""
  },
  {
    "type": "else_if",
    "message0": "else if %1 sentencias %2",
    "args0": [
      {
        "type": "input_value",
        "name": "condicion"
      },
      {
        "type": "input_statement",
        "name": "acciones"
      }
    ],
    "previousStatement": null,
    "nextStatement": null,
    "colour": 0,
    "tooltip": "",
    "helpUrl": ""
  },
  {
    "type": "switch",
    "message0": "switch %1 %2",
    "args0": [
      {
        "type": "input_value",
        "name": "switch"
      },
      {
        "type": "input_statement",
        "name": "NAME"
      }
    ],
    "previousStatement": null,
    "nextStatement": null,
    "colour": 0,
    "tooltip": "",
    "helpUrl": ""
  },
  {
    "type": "case",
    "message0": "case %1 %2",
    "args0": [
      {
        "type": "input_value",
        "name": "case"
      },
      {
        "type": "input_statement",
        "name": "NAME"
      }
    ],
    "previousStatement": null,
    "nextStatement": null,
    "colour": 0,
    "tooltip": "",
    "helpUrl": ""
  },
  {
    "type": "default",
    "message0": "default %1",
    "args0": [
      {
        "type": "input_statement",
        "name": "default"
      }
    ],
    "previousStatement": null,
    "nextStatement": null,
    "colour": 0,
    "tooltip": "",
    "helpUrl": ""
  },
  {
    "type": "detener",
    "message0": "break",
    "previousStatement": null,
    "nextStatement": null,
    "colour": 0,
    "tooltip": "",
    "helpUrl": ""
  },//------------------------ ciclos-------------
  {
    "type": "while",
    "message0": "while %1 %2",
    "args0": [
      {
        "type": "input_value",
        "name": "condicion"
      },
      {
        "type": "input_statement",
        "name": "acciones"
      }
    ],
    "previousStatement": null,
    "nextStatement": null,
    "colour": 180,
    "tooltip": "",
    "helpUrl": ""
  },
  {
    "type": "do_while",
    "message0": "do %1 while %2",
    "args0": [
      {
        "type": "input_statement",
        "name": "acciones"
      },
      {
        "type": "input_value",
        "name": "condicion"
      }
    ],
    "previousStatement": null,
    "nextStatement": null,
    "colour": 180,
    "tooltip": "",
    "helpUrl": ""
  },
  {
    "type": "for",
    "message0": "for ( %1 ; %2 ; %3 ) %4 %5",
    "args0": [
      {
        "type": "input_value",
        "name": "inicializacion"
      },
      {
        "type": "input_value",
        "name": "condicion"
      },
      {
        "type": "input_value",
        "name": "actualizaccion"
      },
      {
        "type": "input_dummy"
      },
      {
        "type": "input_statement",
        "name": "acciones"
      }
    ],
    "previousStatement": null,
    "nextStatement": null,
    "colour": 180,
    "tooltip": "",
    "helpUrl": ""
  },//---------- Procedimientos llamadas
  {
    "type": "llamada_funcion",
    "message0": "funcion %1 ()",
    "args0": [
      {
        "type": "input_value",
        "name": "funcion"
      }
    ],
    "output": null,
    "colour": 260,
    "tooltip": "",
    "helpUrl": ""
  },
  {
    "type": "llamda_funciones_2",
    "message0": "funcion %1 parametro ( %2 )",
    "args0": [
      {
        "type": "input_value",
        "name": "funcion"
      },
      {
        "type": "input_value",
        "name": "parametros"
      }
    ],
    "output": null,
    "colour": 260,
    "tooltip": "",
    "helpUrl": ""
  },
  {
    "type": "log",
    "message0": "log %1",
    "args0": [
      {
        "type": "input_value",
        "name": "log"
      }
    ],
    "previousStatement": null,
    "nextStatement": null,
    "colour": 300,
    "tooltip": "",
    "helpUrl": ""
  },
  {
    "type": "llamada_proc",
    "message0": "call %1 ()",
    "args0": [
      {
        "type": "input_value",
        "name": "nomblre"
      }
    ],
    "output": null,
    "colour": 300,
    "tooltip": "",
    "helpUrl": ""
  },
  {
    "type": "llamada_proc_2",
    "message0": "call %1 ( %2 )",
    "args0": [
      {
        "type": "input_value",
        "name": "nombre"
      },
      {
        "type": "input_value",
        "name": "parametros"
      }
    ],
    "output": null,
    "colour": 300,
    "tooltip": "",
    "helpUrl": ""
  },
  {
    "type": "llamada_proc_3",
    "message0": "call %1 ( %2 )",
    "args0": [
      {
        "type": "input_value",
        "name": "nombre"
      },
      {
        "type": "input_value",
        "name": "parametros"
      }
    ],
    "previousStatement": null,
    "nextStatement": null,
    "colour": 300,
    "tooltip": "",
    "helpUrl": ""
  },
  {
    "type": "llamada_proc_4",
    "message0": "call %1 ()",
    "args0": [
      {
        "type": "input_value",
        "name": "nomblre"
      }
    ],
    "previousStatement": null,
    "nextStatement": null,
    "colour": 300,
    "tooltip": "",
    "helpUrl": ""
  },
  {
    "type": "incremento_decremento_2",
    "message0": "%1 %2",
    "args0": [
      {
        "type": "input_value",
        "name": "variable"
      },
      {
        "type": "field_dropdown",
        "name": "ope",
        "options": [
          [
            "++",
            "++"
          ],
          [
            "--",
            "--"
          ]
        ]
      }
    ],
    "previousStatement": null,
    "nextStatement": null,
    "colour": 260,
    "tooltip": "",
    "helpUrl": ""
  }, {
    "type": "llamada_funcion_3",
    "message0": "funcion %1 ()",
    "args0": [
      {
        "type": "input_value",
        "name": "funcion"
      }
    ],
    "previousStatement": null,
    "nextStatement": null,
    "colour": 260,
    "tooltip": "",
    "helpUrl": ""
  },
  {
    "type": "llamda_funciones_4",
    "message0": "funcion %1 parametro ( %2 )",
    "args0": [
      {
        "type": "input_value",
        "name": "funcion"
      },
      {
        "type": "input_value",
        "name": "parametros"
      }
    ],
    "previousStatement": null,
    "nextStatement": null,
    "colour": 260,
    "tooltip": "",
    "helpUrl": ""
  }

]);


