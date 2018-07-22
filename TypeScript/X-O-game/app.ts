

function nextTurn(num1: number, user: string, id: string): void {


    console.log(num1);
    let a = document.getElementById(id) as HTMLElement;

    a.setAttribute("disabled", "");
    let play: BuildSchema = new BuildSchema;
    play.schemaFun(num1, user, id);
}

function overlay(id: string): void {

    document.getElementById(id).style.display = 'none';
}