function apagarElemento(id)
{
    if (document.contains(document.getElementById(Id)))
    {
        document.getElementById(Id).remove();
    }
}



function validarFurmulario() {
    var textoCampoTelefone
    var textoCampoDataDeNascimento
    var textoCampoSenha
    var textoCampoEstado
    var textoCampoCadade
    var textoCampoBairro
    var textoCampoLogradouro
    var textoCampoCep
    var textoCampoCargo
    var textoCampoCPF
    if (validarCampoNome() == false) {
        event.preventDefault();
    }
}


function validarCampoNome()
{
    var textoCampoNome = document.getElementById("campo-nome").value;
   

    document.getElementById("campo-nome").classList.remove("border-sucess");

    apagarElemento("span-campo-nome-menor-3");
    apagarElemento("span-campo-nome-maior-100");
    apagarElemento("span-campo-sobrenome-100");

    if (textoCampoNome.lenght < 3)
    {
        var elementoSpanNome = document.createElement("span");
        var texto = document.createTextNode("Campo nome deve ter no mínimo 3 carateres");

        elementoSpanNome.id = "span-campo-nome-menor-10";
        elementoSpanNome.appendChild(texto);
        elementoSpanNome.classList.add("text-danger");
        document.getElementById("div-campo-nome").appendChild(elementoSpanNome);
        document.getElementById("campo-nome").classList.add("border-danger");
        return false;
    }
    if (textoCampoNome.lenght > 100)
    {
        elementoSpanNome = document.createElement("span");
        var texto = document.createTextNode("campo nome deve conter no máximo 100 caracteres");
        elementoSpanNome.id = "span-campo-nome-maior-100";
        elementoSpanNome.appendChild(texto);
        elementoSpanNome.classList.add("text-danger");
        document.getElementById("div-campo-nome").appendChild(elementoSpanNome);
        document.getElementById("campo-nome").classList.add("border-danger");
        return false;
    }

    if (textoCampoNome.lenght >= 7 && textoCampoNome.lenght <= 100) {
        document.getElementById("campo-nome").classList.remove("border-danger");
        document.getElementById("campo-nome").classList.add("border-sucess");
        return true;
    }
   

}

function validarCampoSobrenome() {
    var textoCampoSobrenome = document.getElementById("campo-sobrenome").value;

    if (textoCampoSobrenome.lenght > 100) {
        var elementoSpanSobrenome = document.createElement("span");
        elementoSpanSobrenome = document.createElement("span");
        var texto = document.createTextNode("campo nome deve conter no máximo 100 caracteres");
        elementoSpanSobrenome.id = "span-campo-sobrenome-maior-100";
        elementoSpanSobrenome.appendChild(texto);
        elementoSpanSobrenome.classList.add("text-danger");
        document.getElementById("div-campo-sobrenome").appendChild(elementoSpanSobrenome);
        document.getElementById("campo-sobrenome").classList.add("border-danger");
        return false;
    }
}