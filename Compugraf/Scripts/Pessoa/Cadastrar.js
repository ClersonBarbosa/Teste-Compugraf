
function montarObjetoCadastrar() {
    return {
        'Nome': ($("#txtNome").val()),
        'Sobrenome': ($("#txtSobrenome").val()),
        'Nacionalidade': ($("#txtNacionalidade").val()),
        'Cep': ($("#txtCep").val()),
        'Estado': ($("#txtEstado").val()),
        'Cidade': ($("#txtCidade").val()),
        'Logradouro': ($("#txtLogradouro").val()),
        'Email': ($("#txtEmail").val()),
        'Telefone': ($("#txtTelefone").val())
    }
}

function CadastrarPessoa() {
    if (validarFormulario())
        postCadastrar(montarObjetoCadastrar(), '/Pessoa/CadastrarPessoa')
}

function postCadastrar(data, url) {
    $.ajax({
        url: url,
        data: JSON.stringify(data),
        type: 'POST',
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        success: function (json) {

            swal.close();
            if (json.status) {

                showMessage('success', 'Sucesso', 'A Pessoa foi cadastrada!')
            }
            else {
                showMessage('error', 'Oops...', 'Ocorreu um erro ao cadastrar a  Pessoa!')
            }
            LimparCampos();
        },
        error: function (json) {

            showMessage('error', 'Oops...', 'Ocorreu um erro!')

        }

    })
}


function montarObjetoEditar() {
    return {
        'Id': ($("#Id").val()),
        'Nome': ($("#txtNome").val()),
        'Sobrenome': ($("#txtSobrenome").val()),
        'Nacionalidade': ($("#txtNacionalidade").val()),
        'Cep': ($("#txtCep").val()),
        'Estado': ($("#txtEstado").val()),
        'Cidade': ($("#txtCidade").val()),
        'Logradouro': ($("#txtLogradouro").val()),
        'Email': ($("#txtEmail").val()),
        'Telefone': ($("#txtTelefone").val())
    }
}

function validarFormulario() {
    var mensagem = '';

    if ($('#txtNome').val() == '') {
        mensagem += ' Nome';
    }

    if ($('#txtSobrenome').val() == '') {
        mensagem += ' Sobrenome';
    }

    if ($('#txtNacionalidade').val() == '') {
        mensagem += ' Nacionalidade';
    }

    if ($('#txtCep').val() == '') {
        mensagem += ' Cep';
    }

    if ($('#txtEstado').val() == '') {
        mensagem += ' Estado';
    }

    if ($('#txtCidade').val() == '') {
        mensagem += ' Cidade';
    }

    if ($('#txtLogradouro').val() == '') {
        mensagem += ' Logradouro';
    }

    if ($('#txtEmail').val() == '') {
        mensagem += ' Email';
    }

    if ($('#txtTelefone').val() == '') {
        mensagem += ' Telefone';
    }

    if (mensagem == '')
        return true;

    showMessage('warning', 'Ops! Favor preencher o campo.', mensagem)
}

function LimparCampos() {
    $("#txtNome").val("");
    $("#txtSobrenome").val("");
    $("#txtNacionalidade").val("");
    $("#txtCep").val("");
    $("#txtEstado").val("");
    $("#txtCidade").val("");
    $("#txtLogradouro").val("");
    $("#txtEmail").val("");
    $("#txtTelefone").val("");

function MascaraCampos() {
    $("#txtTelefone").mask("(00)0000-0000");
}

var id_tela = 0;
window.onload = () => {

    MascaraCampos();
    LimparPessoa();

    var url = new URL(window.location);
    var titulo = "";

    var sp = new URLSearchParams(url.search);
    if (sp.get('id')) {
        id_tela = $.urlParam('id');
    }

    if (id_tela == 0) {
        titulo = "Cadastrar Pessoa";

        $("#btnSalvar").css('display', 'block');
    }

    $("#lbl_titulo").html(titulo);
}