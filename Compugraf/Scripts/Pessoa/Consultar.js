function MostrarGrid() {
    $("#Grid").css('display', 'block');
}

function OcultarGrid() {
    $("#Grid").css('display', 'none');
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
}

function Pesquisar() {

    CarregarGrid();
}

var oTable;
var teste = 0;

function CarregarGrid() {
    MostrarGrid();
    if (teste == 1) {
        oTable.destroy();
    }
    teste = 1;
    oTable = $("#myDataTable").DataTable({

        "language": {
            "lengthMenu": "Exibe _MENU_ Registros por página",
            "search": "Procurar",
            "paginate": { "previous": "Retorna", "next": "Avança" },
            "zeroRecords": "Nenhum registro foi encontrado",
            "info": "Exibindo página _PAGE_ de _PAGES_",
            "infoEmpty": "Sem registros",
            "infoFiltered": "(filtrado de _MAX_ regitros totais)"
        },
        "processing": true, // mostrar a progress bar
        //"serverSide": true, // processamento no servidor
        "filter": true, // habilita o filtro(search box)
        "lengthMenu": [[3, 5, 10, 25, 50, -1], [3, 5, 10, 25, 50, "Todos"]],
        "pageLength": 10, // define o tamanho da página
        "ajax": {
            "url": "/Pessoa/ConsultarPessoa",
            "type": "GET",
            "dataType": "json",
        },

        "columns": [
            { "data": "Nome", "title": "Nome" },
            { "data": "Sobrenome", "title": "Sobrenome" },
            { "data": "Nacionalidade", "title": "Nacionalidade" },
            { "data": "Cep", "title": "Cep" },
            { "data": "Estado", "title": "Estado" },
            { "data": "Cidade", "title": "Cidade" },
            { "data": "Logradouro", "title": "Logradouro" },
            { "data": "Email", "title": "Email" },
            { "data": "Telefone", "title": "Telefone" },
            {
                "data": function (data) {
                    return '&nbsp<a href="#" class="btn-danger btn-sm"><span class="glyphicon glyphicon-remove" onclick="DeletarPessoa(' + data.Id + ');" title="Excluir"></span><a/>';
                }
            }
        ]

    })

}

function DeletarPessoa(id) {
    Swal.fire({
        title: 'Atenção!',
        text: "Deseja excluir esse registro id: " + id,
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#00CD00',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Deletar'
    }).then((result) => {
        if (result.value) {
            ExcluirRegistro(id);
        }
        CarregarGrid();
    })
}

function ExcluirRegistro(id) {
    $.ajax({
        url: "/Pessoa/ExcluirPessoa",
        async: false,
        data: { 'ID': id },

        success: function (json) {

            swal.close();
            if (json.status) {
                CarregarGrid();
            }
            else {
                showMessage('error', 'Oops...', 'Ocorreu um erro  ao carregar dados!')
            }
        }
    });
}

window.onload = function () {
    OcultarGrid();
    CarregarGrid();
};