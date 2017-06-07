
        function enviarEndereco() {
            var rua = $("#txtRua").val();
            var numero = $("#txtNumero").val();
            var bairro = $("#txtBairro").val();
            var complemento = $("#txtComplemento").val();
            var cep = $("#txtCEP").val();
            var cidade = $("#txtCidade").val();
            var jsonText = JSON.stringify({ rua: rua, numero: numero, bairro: bairro, complemento: complemento, cep: cep, cidade: cidade });
            $.ajax({
                type: 'POST',
                url: 'NewCadastroUsuario.aspx/EnviarEndereco',
                data: jsonText,
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (r) {
                    alert('Nome Agrupado');
                }
            });
        }

       