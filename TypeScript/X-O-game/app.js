function nextTurn(num1, user, id) {
    console.log(num1);
    var a = document.getElementById(id);
    a.setAttribute("disabled", "");
    var play = new BuildSchema;
    play.schemaFun(num1, user, id);
}
function overlay(id) {
    document.getElementById(id).style.display = 'none';
}
//# sourceMappingURL=app.js.map