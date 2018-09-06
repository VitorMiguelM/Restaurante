function apagarElemento(id)
{
    if (document.contains(document.getElementById(id)))
    {
        document.getElementById(id).remove();
    }
}

function validarFormulario()
{
    var textoCampoCPF
    var textoCampoMesa
    var textoCampoHorario
    var textoCampoPagamento
    if (validarLogin() == false) {
        event.preventDefault();
    }

    validarLogin();
    
}


function validarLogin()
{
    var textoCampoLogin = document.getElementById("campo-nome").value;

    document.getElementById("campo-nome").classList.remove("border-sucess");

    apagarElemento("span-campo-nome-menor-3");

    apagarElemento("span-campo-nome-maior-100");

    if (textoCampoLogin.length < 3)
    {
        var elementoSpanLogin = document.createElement("span");

        var texto = document.createTextNode("Campo login deve ter no mínimo 3 caracteres");

        elementoSpanLogin.id = "span-campo-nome-menor-3";

        elementoSpanLogin.appendChild(texto);

        elementoSpanLogin.classList.add("text-danger");

        document.getElementById("div-campo-nome").appendChild(elementoSpanLogin);

        document.getElementById("campo-nome").classList.add("border-danger");

        return false;
    }

    if (textoCampoLogin.length > 100)
    {
        elementoSpanLogin = document.createElement("span");

        var texto = document.createTextNode("Campo login deve ter no máximo 100 caracteres");

        elementoSpanLogin.id = "span-campo-nome-maior-100";

        elementoSpanLogin.appendChild(texto);

        elementoSpanLogin.classList.add("text-denger");

        document.getElementById("div-campo-nome").appendChild(elementoSpanLogin);

        document.getElementById("campo-nome").classList.add("border-danger");

        document.getElementById()
    }

    if (textoCampoLogin.length >= 3 && textoCampoLogin.length <= 100) {
        document.getElementById("campo-nome").classList.remove("border-danger");

        document.getElementById("campo-nome").classList.add("border-sucess");
    }
}