class BuildSchema implements ISchemafun{


    private static _iSchema: Array<Array<string>> = [["1", "2", "3"], ["4", "5", "6"], ["7", "8", "9"]];

    private static _userWin: Array<Array<string>> = [["1", "2", "3"], ["4", "5", "6"], ["7", "8", "9"],
        ["1", "5", "9"], ["1", "4", "7"], ["2", "5", "8"], ["3", "6", "9"], ["7", "5", "3"]];

    private static _compWin: Array<Array<string>> = [["1", "2", "3"], ["4", "5", "6"], ["7", "8", "9"],
        ["1", "5", "9"], ["1", "4", "7"], ["2", "5", "8"], ["3", "6", "9"], ["3", "5", "7"]];
    private static turn: number = 1;

    
    public schemaFun(userNum: number, user: string, id: string): void {
        
        for (let i: number = 0; i < BuildSchema._iSchema.length; i++) {
            for (let j: number = 0; j < BuildSchema._iSchema[i].length; j++) {
                if (BuildSchema._iSchema[i][j] == userNum.toString())
                    if (user == "o") {
                        BuildSchema._iSchema[i][j] = "O";
                    }
                    else { BuildSchema._iSchema[i][j] = "X" }
            }
        }

        for (let i: number = 0; i < BuildSchema._compWin.length; i++) {
            for (let j: number = 0; j < BuildSchema._compWin[i].length; j++) {
                if (BuildSchema._compWin[i][j] == userNum.toString())
                    if (user == "o") {
                        BuildSchema._userWin[i][j] = "O";
                        BuildSchema._compWin[i][j] = "O";
                    }
                    else { BuildSchema._userWin[i][j] = "X"; BuildSchema._compWin[i][j] = "X"; }
            }
        }

        BuildSchema.turn++;
        BuildSchema.PCwin(userNum);

    }


    public static PCwin(userNum: number): void {
        let bool: boolean = true;
        for (let i: number = 0; i < BuildSchema._compWin.length; i++) {
            let compwin: number = 0;
            let userwin: number = 0;
            for (let j: number = 0; j < BuildSchema._compWin[i].length; j++) {

                if (BuildSchema._compWin[i][j] == "O") {
                    compwin++;
                    if (compwin == 3) { bool = false; }
                }
                else if (BuildSchema._compWin[i][j] == "X") {
                    userwin++;
                    if (userwin == 3) { bool = false; }
                }
            }
        }
        if (BuildSchema.turn % 2 == 0) {
            if (BuildSchema.turn == 2) {
                let i: number;
                let z: number;
                switch (userNum) {
                    case 1: i = 2; z = 2; break;
                    case 2: i = 2; z = 2; break;
                    case 3: i = 2; z = 2; break;
                    case 4: i = 2; z = 2; break;
                    case 5: i = 1; z = 1; break;
                    case 6: i = 2; z = 2; break;
                    case 7: i = 2; z = 2; break;
                    case 8: i = 2; z = 2; break;
                    case 9: i = 2; z = 2; break;
                }
                if (bool) {
                    bool = false;
                    let a = document.getElementById(`block${BuildSchema.turn}-${[i]}-${[z]}`) as HTMLElement;
                    a.click();
                }

            }
            if (BuildSchema.turn % 2 == 0) {
                for (let i: number = 0; i < BuildSchema._compWin.length; i++) {
                    let compwin: number = 0;
                    for (let j: number = 0; j < BuildSchema._compWin[i].length; j++) {
                        if (BuildSchema._compWin[i][j] == "O") {
                            compwin++;
                            if (compwin == 2) {
                                for (let z: number = 0; z < BuildSchema._compWin[i].length; z++) {
                                    if (BuildSchema._compWin[i][z] != "O" && BuildSchema._compWin[i][z] != "X") {
                                        let arr: Array<number> = BuildSchema.location(i, z);
                                        if (bool) {
                                            bool = false;
                                            let a = document.getElementById(`block${BuildSchema.turn}-${arr[0]}-${arr[1]}`) as HTMLElement;
                                            a.click();
                                        }

                                    }
                                }
                            }
                        }
                    }

                }
            }
            if (BuildSchema.turn % 2 == 0) {
                for (let i: number = 0; i < BuildSchema._userWin.length; i++) {
                    let compwin: number = 0;
                    for (let j: number = 0; j < BuildSchema._userWin[i].length; j++) {
                        if (BuildSchema._userWin[i][j] == "X") {
                            compwin++;
                            if (compwin == 2) {
                                for (let z: number = 0; z < BuildSchema._userWin[i].length; z++) {
                                    if (BuildSchema._compWin[i][z] != "O" && BuildSchema._compWin[i][z] != "X") {
                                        let arr: Array<number> = BuildSchema.location(i, z);
                                        if (bool) {
                                            bool = false;
                                            let a = document.getElementById(`block${BuildSchema.turn}-${arr[0]}-${arr[1]}`) as HTMLElement;
                                            a.click();
                                        }

                                    }
                                }
                            }
                        }
                    }

                }
            }

            if (BuildSchema.turn % 2 == 0) {
                for (let i: number = 0; i < BuildSchema._userWin.length; i++) {
                    let compwin: number = 0;
                    for (let j: number = 0; j < BuildSchema._userWin[i].length; j++) {
                        if (BuildSchema._userWin[i][j] == "X") { compwin++; }
                        if (compwin == 0 && j == 2) {
                            for (let z: number = 0; z < BuildSchema._userWin[i].length; z++) {
                                if (BuildSchema._compWin[i][z] != "O" && BuildSchema._compWin[i][z] != "X") {
                                    let arr: Array<number> = BuildSchema.location(i, z);

                                    if (bool) {
                                        bool = false;
                                        let a = document.getElementById(`block${BuildSchema.turn}-${arr[0]}-${arr[1]}`) as HTMLElement;
                                        a.click();
                                    }

                                }
                            }
                        }
                    }
                }
            }
            if (BuildSchema.turn % 2 == 0) {
                for (let i: number = 0; i < BuildSchema._userWin.length; i++) {
                    let compwin: number = 0;
                    for (let j: number = 0; j < BuildSchema._userWin[i].length; j++) {
                        for (let z: number = 0; z < BuildSchema._userWin[i].length; z++) {
                            if (BuildSchema._compWin[i][z] != "O" && BuildSchema._compWin[i][z] != "X") {
                                let arr: Array<number> = BuildSchema.location(i, z);

                                if (bool) {
                                    bool = false;
                                    let a = document.getElementById(`block${BuildSchema.turn}-${arr[0]}-${arr[1]}`) as HTMLElement;
                                    a.click();
                                }

                            }
                        }
                    }
                }
            }
        }
    }
    public static location(i: number, z: number): Array<number> {

        switch (BuildSchema._compWin[i][z]) {
            case "1": i = 1; z = 1; break;
            case "2": i = 1; z = 2; break;
            case "3": i = 1; z = 3; break;
            case "4": i = 2; z = 1; break;
            case "5": i = 2; z = 2; break;
            case "6": i = 2; z = 3; break;
            case "7": i = 3; z = 1; break;
            case "8": i = 3; z = 2; break;
            case "9": i = 3; z = 3; break;
        }
        if (BuildSchema.turn == 4 && BuildSchema._iSchema[0][0] == "X" && BuildSchema._iSchema[1][2] == "X")
        { i = 1; z = 3; }
        if (BuildSchema.turn == 4 && BuildSchema._iSchema[1][2] == "X" && BuildSchema._iSchema[2][1] == "X")
        { i = 3; z = 3; }
        if (BuildSchema.turn == 4 && BuildSchema._iSchema[1][1] == "X" && BuildSchema._iSchema[2][2] == "X")
        { i = 3; z = 1; }
        if (BuildSchema.turn == 4 && BuildSchema._iSchema[2][0] == "X" && BuildSchema._iSchema[1][2] == "X")
        { i = 3; z = 3; }
        if (BuildSchema.turn == 4 && BuildSchema._iSchema[0][1] == "X" && BuildSchema._iSchema[1][2] == "X")
        { i = 3; z = 3; }
        if (BuildSchema.turn == 4 && BuildSchema._iSchema[0][1] == "X" && BuildSchema._iSchema[1][2] == "X")
        { i = 3; z = 3; }
        if (BuildSchema.turn == 4 && BuildSchema._iSchema[2][0] == "X" && BuildSchema._iSchema[0][1] == "X")
        { i = 2; z = 3; }
       

        let arr: Array<number> = [i, z]
        return arr;
    }
}



