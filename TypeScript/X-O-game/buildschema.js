var BuildSchema = (function () {
    function BuildSchema() {
    }
    BuildSchema.prototype.schemaFun = function (userNum, user, id) {
        for (var i = 0; i < BuildSchema._iSchema.length; i++) {
            for (var j = 0; j < BuildSchema._iSchema[i].length; j++) {
                if (BuildSchema._iSchema[i][j] == userNum.toString())
                    if (user == "o") {
                        BuildSchema._iSchema[i][j] = "O";
                    }
                    else {
                        BuildSchema._iSchema[i][j] = "X";
                    }
            }
        }
        for (var i = 0; i < BuildSchema._compWin.length; i++) {
            for (var j = 0; j < BuildSchema._compWin[i].length; j++) {
                if (BuildSchema._compWin[i][j] == userNum.toString())
                    if (user == "o") {
                        BuildSchema._userWin[i][j] = "O";
                        BuildSchema._compWin[i][j] = "O";
                    }
                    else {
                        BuildSchema._userWin[i][j] = "X";
                        BuildSchema._compWin[i][j] = "X";
                    }
            }
        }
        BuildSchema.turn++;
        BuildSchema.PCwin(userNum);
    };
    BuildSchema.PCwin = function (userNum) {
        var bool = true;
        for (var i = 0; i < BuildSchema._compWin.length; i++) {
            var compwin = 0;
            var userwin = 0;
            for (var j = 0; j < BuildSchema._compWin[i].length; j++) {
                if (BuildSchema._compWin[i][j] == "O") {
                    compwin++;
                    if (compwin == 3) {
                        bool = false;
                    }
                }
                else if (BuildSchema._compWin[i][j] == "X") {
                    userwin++;
                    if (userwin == 3) {
                        bool = false;
                    }
                }
            }
        }
        if (BuildSchema.turn % 2 == 0) {
            if (BuildSchema.turn == 2) {
                var i = void 0;
                var z = void 0;
                switch (userNum) {
                    case 1:
                        i = 2;
                        z = 2;
                        break;
                    case 2:
                        i = 2;
                        z = 2;
                        break;
                    case 3:
                        i = 2;
                        z = 2;
                        break;
                    case 4:
                        i = 2;
                        z = 2;
                        break;
                    case 5:
                        i = 1;
                        z = 1;
                        break;
                    case 6:
                        i = 2;
                        z = 2;
                        break;
                    case 7:
                        i = 2;
                        z = 2;
                        break;
                    case 8:
                        i = 2;
                        z = 2;
                        break;
                    case 9:
                        i = 2;
                        z = 2;
                        break;
                }
                if (bool) {
                    bool = false;
                    var a = document.getElementById("block" + BuildSchema.turn + "-" + [i] + "-" + [z]);
                    a.click();
                }
            }
            if (BuildSchema.turn % 2 == 0) {
                for (var i = 0; i < BuildSchema._compWin.length; i++) {
                    var compwin = 0;
                    for (var j = 0; j < BuildSchema._compWin[i].length; j++) {
                        if (BuildSchema._compWin[i][j] == "O") {
                            compwin++;
                            if (compwin == 2) {
                                for (var z = 0; z < BuildSchema._compWin[i].length; z++) {
                                    if (BuildSchema._compWin[i][z] != "O" && BuildSchema._compWin[i][z] != "X") {
                                        var arr = BuildSchema.location(i, z);
                                        if (bool) {
                                            bool = false;
                                            var a = document.getElementById("block" + BuildSchema.turn + "-" + arr[0] + "-" + arr[1]);
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
                for (var i = 0; i < BuildSchema._userWin.length; i++) {
                    var compwin = 0;
                    for (var j = 0; j < BuildSchema._userWin[i].length; j++) {
                        if (BuildSchema._userWin[i][j] == "X") {
                            compwin++;
                            if (compwin == 2) {
                                for (var z = 0; z < BuildSchema._userWin[i].length; z++) {
                                    if (BuildSchema._compWin[i][z] != "O" && BuildSchema._compWin[i][z] != "X") {
                                        var arr = BuildSchema.location(i, z);
                                        if (bool) {
                                            bool = false;
                                            var a = document.getElementById("block" + BuildSchema.turn + "-" + arr[0] + "-" + arr[1]);
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
                for (var i = 0; i < BuildSchema._userWin.length; i++) {
                    var compwin = 0;
                    for (var j = 0; j < BuildSchema._userWin[i].length; j++) {
                        if (BuildSchema._userWin[i][j] == "X") {
                            compwin++;
                        }
                        if (compwin == 0 && j == 2) {
                            for (var z = 0; z < BuildSchema._userWin[i].length; z++) {
                                if (BuildSchema._compWin[i][z] != "O" && BuildSchema._compWin[i][z] != "X") {
                                    var arr = BuildSchema.location(i, z);
                                    if (bool) {
                                        bool = false;
                                        var a = document.getElementById("block" + BuildSchema.turn + "-" + arr[0] + "-" + arr[1]);
                                        a.click();
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (BuildSchema.turn % 2 == 0) {
                for (var i = 0; i < BuildSchema._userWin.length; i++) {
                    var compwin = 0;
                    for (var j = 0; j < BuildSchema._userWin[i].length; j++) {
                        for (var z = 0; z < BuildSchema._userWin[i].length; z++) {
                            if (BuildSchema._compWin[i][z] != "O" && BuildSchema._compWin[i][z] != "X") {
                                var arr = BuildSchema.location(i, z);
                                if (bool) {
                                    bool = false;
                                    var a = document.getElementById("block" + BuildSchema.turn + "-" + arr[0] + "-" + arr[1]);
                                    a.click();
                                }
                            }
                        }
                    }
                }
            }
        }
    };
    BuildSchema.location = function (i, z) {
        switch (BuildSchema._compWin[i][z]) {
            case "1":
                i = 1;
                z = 1;
                break;
            case "2":
                i = 1;
                z = 2;
                break;
            case "3":
                i = 1;
                z = 3;
                break;
            case "4":
                i = 2;
                z = 1;
                break;
            case "5":
                i = 2;
                z = 2;
                break;
            case "6":
                i = 2;
                z = 3;
                break;
            case "7":
                i = 3;
                z = 1;
                break;
            case "8":
                i = 3;
                z = 2;
                break;
            case "9":
                i = 3;
                z = 3;
                break;
        }
        if (BuildSchema.turn == 4 && BuildSchema._iSchema[0][0] == "X" && BuildSchema._iSchema[1][2] == "X") {
            i = 1;
            z = 3;
        }
        if (BuildSchema.turn == 4 && BuildSchema._iSchema[1][2] == "X" && BuildSchema._iSchema[2][1] == "X") {
            i = 3;
            z = 3;
        }
        if (BuildSchema.turn == 4 && BuildSchema._iSchema[1][1] == "X" && BuildSchema._iSchema[2][2] == "X") {
            i = 3;
            z = 1;
        }
        if (BuildSchema.turn == 4 && BuildSchema._iSchema[2][0] == "X" && BuildSchema._iSchema[1][2] == "X") {
            i = 3;
            z = 3;
        }
        if (BuildSchema.turn == 4 && BuildSchema._iSchema[0][1] == "X" && BuildSchema._iSchema[1][2] == "X") {
            i = 3;
            z = 3;
        }
        if (BuildSchema.turn == 4 && BuildSchema._iSchema[0][1] == "X" && BuildSchema._iSchema[1][2] == "X") {
            i = 3;
            z = 3;
        }
        if (BuildSchema.turn == 4 && BuildSchema._iSchema[2][0] == "X" && BuildSchema._iSchema[0][1] == "X") {
            i = 2;
            z = 3;
        }
        var arr = [i, z];
        return arr;
    };
    BuildSchema._iSchema = [["1", "2", "3"], ["4", "5", "6"], ["7", "8", "9"]];
    BuildSchema._userWin = [["1", "2", "3"], ["4", "5", "6"], ["7", "8", "9"],
        ["1", "5", "9"], ["1", "4", "7"], ["2", "5", "8"], ["3", "6", "9"], ["7", "5", "3"]];
    BuildSchema._compWin = [["1", "2", "3"], ["4", "5", "6"], ["7", "8", "9"],
        ["1", "5", "9"], ["1", "4", "7"], ["2", "5", "8"], ["3", "6", "9"], ["3", "5", "7"]];
    BuildSchema.turn = 1;
    return BuildSchema;
}());
//# sourceMappingURL=buildschema.js.map