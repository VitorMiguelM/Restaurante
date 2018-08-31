function apagarElemento(id)
{
    if (document.contains(document.getElementById(id)))
    {
        document.getElementById(id).remove();
    }
}

function validarFormulario()
{
    var textoCampoCPF = document.getElementById("cpf").value;
    var textoCampoMesa = document.getElementById("mesa");
    var textoCampoHorario = document.getElementById("horario");
    var textoCampoPagamento = document.getElementById("pagamento")
    if (validarLogin() == false) {
        event.preventDefault();
    }

    validarLogin();
    
}


function validarLogin()
{
    var textoCampoLogin = document.getElementById("nome").value;

    document.getElementById("nome").classList.remove("border-sucess");

    apagarElemento("span-nome-menor-3");

    apagarElemento("span-nome-maior-100");

    if (textoCampoLogin.length < 3)
    {
        var elementoSpanLogin = document.createElement("span");

        var texto = document.createTextNode("Campo login deve ter no mínimo 3 caracteres");

        elementoSpanLogin.id = "span-nome-menor-3";

        elementoSpanLogin.appendChild(texto);

        elementoSpanLogin.classList.add("text-danger");

        document.getElementById("div-nome").appendChild(elementoSpanLogin);

        document.getElementById("nome").classList.add("border-danger");

        return false;
    }

    if (textoCampoLogin.length > 100)
    {
        elementoSpanLogin = document.createElement("span");

        var texto = document.createTextNode("Campo login deve ter no máximo 100 caracteres");

        elementoSpanLogin.id = "span-nome-maior-100";

        elementoSpanLogin.appendChild(texto);

        elementoSpanLogin.classList.add("text-denger");

        document.getElementById("div-nome").appendChild(elementoSpanLogin);

        document.getElementById("nome").classList.add("border-danger");

        document.getElementById()
    }

    if (textoCampoLogin.length >= 3 && textoCampoLogin.length <= 100) {
        document.getElementById("nome").classList.remove("border-danger");

        document.getElementById("nome").classList.add("border-sucess");
    }
}