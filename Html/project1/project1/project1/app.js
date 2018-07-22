//********************Function Section********************
document.write("" + (Math.round(55).toFixed(2)));
//prints full square 
function printFullSquare(a) {
    for (var i = 1; i <= a; i++) {
        for (var j = 1; j <= a; j++) {
            document.write("* ");
        }
        document.write(" <br/>");
    }
}
//prints full triangle 
function printFullTriangle(a) {
    for (var i = 1; i <= a; i++) {
        for (var j = 1; j <= i; j++) {
            document.write("* ");
        }
        document.write(" <br/>");
    }
}
//prints full rectangle
function printFullRectangle(a, b) {
    for (var i = 1; i <= a; i++) {
        for (var j = 1; j <= b; j++) {
            document.write("* ");
        }
        document.write(" <br/>");
    }
}
//prints full diamond
function printFullDiamond(a) {
    for (var i = 1; i <= a; i++) {
        for (var j = i; j < a; j++) {
            document.write("&nbsp");
        }
        for (var j = 1; j <= i; j++) {
            document.write("* ");
        }
        document.write(" <br/>");
    }
    for (var i = 1; i <= a; i++) {
        document.write("&nbsp");
        for (var j = 1; j < i; j++) {
            document.write("&nbsp");
        }
        for (var j = 1; j <= (a - i); j++) {
            document.write("* ");
        }
        document.write(" <br/>");
    }
}
//prints hollow square
function printHollowSquare(a) {
    for (var i = 1; i <= a; i++) {
        for (var j = 1; j <= a; j++) {
            if (i == 1 || i == a || j == 1 || j == a) {
                document.write("* ");
            }
            else {
                document.write("&nbsp ");
            }
        }
        document.write(" <br/>");
    }
}
//prints hollow triangle
function printHollowTriangle(a) {
    for (var i = 1; i <= a; i++) {
        for (var j = 1; j <= i; j++) {
            if (j == 1 || j == i || i == a) {
                document.write("*  ");
            }
            else {
                document.write("&nbsp&nbsp");
            }
        }
        document.write(" <br/>");
    }
}
//prints hollow rectangle
function printHollowRectangle(a, b) {
    for (var i = 1; i <= a; i++) {
        for (var j = 1; j <= b; j++) {
            if (i == 1 || i == a || j == 1 || j == b) {
                document.write("* ");
            }
            else {
                document.write("&nbsp ");
            }
        }
        document.write(" <br/>");
    }
}
//prints hollow diamond
function printHollowDiamond(a) {
    for (var i = 1; i <= a; i++) {
        for (var j = i; j < a; j++) {
            document.write("&nbsp");
        }
        for (var j = 1; j <= i; j++) {
            if (i > 2) {
                if (j == 1 || j == i)
                    document.write("* ");
                else
                    document.write("&nbsp ");
            }
            else
                document.write("* ");
        }
        document.write("<br/>");
    }
    for (var i = 1; i <= a; i++) {
        document.write("&nbsp");
        for (var j = 1; j < i; j++) {
            document.write("&nbsp");
        }
        for (var j = 1; j <= (a - i); j++) {
            if (j == 1 || j == a - i) {
                document.write("* ");
            }
            else {
                document.write("&nbsp ");
            }
        }
        document.write("<br/>");
    }
}
//prints up numbers's square
function printUpNumbersSquare(a) {
    for (var i = 1; i <= a; i++) {
        for (var j = 1; j <= a; j++) {
            document.write(j + " ");
        }
        document.write(" <br/>");
    }
}
//prints up numbers's triangle
function printUpNumbersTriangle(a) {
    for (var i = 1; i <= a; i++) {
        for (var j = 1; j <= i; j++) {
            document.write(j + " ");
        }
        document.write(" <br/>");
    }
}
//prints up numbers's rectangle
function printUpNumbersRectangle(a, b) {
    for (var i = 1; i <= a; i++) {
        for (var j = 1; j <= b; j++) {
            document.write("" + j);
        }
        document.write(" <br/>");
    }
}
//prints up numbers's diamond
function printUpNumbersDiamond(a) {
    for (var i = 1; i <= a; i++) {
        for (var j = i; j < a; j++) {
            document.write("&nbsp");
        }
        for (var j = 1; j <= i; j++) {
            document.write("" + j);
        }
        document.write(" <br/>");
    }
    for (var i = 1; i <= a; i++) {
        document.write("&nbsp");
        for (var j = 1; j < i; j++) {
            document.write("&nbsp");
        }
        for (var j = 1; j <= (a - i); j++) {
            document.write("" + j);
        }
        document.write(" <br/>");
    }
}
//prints down numbers's square
function printDownNumbersSquare(a) {
    for (var i = a; i >= 1; i--) {
        for (var j = a; j >= 1; j--) {
            document.write(j + " ");
        }
        document.write(" <br/>");
    }
}
//prints down numbers's triangle
function printDownNumbersTriangle(a) {
    var counter = a;
    for (var i = 1; i <= a; i++) {
        for (var j = 1; j <= i; j++) {
            document.write(counter + " ");
            counter--;
        }
        counter = a;
        document.write(" <br/>");
    }
}
//prints down numbers's rectangle
function printDownNumbersRectangle(a, b) {
    for (var i = a; i >= 1; i--) {
        for (var j = b; j >= 1; j--) {
            document.write(j + " ");
        }
        document.write(" <br/>");
    }
}
//prints down numbers's diamiond
function printDownNumbersDiamond(a) {
    var counter = a;
    for (var i = 1; i <= a; i++) {
        for (var j = i; j < a; j++) {
            document.write("&nbsp");
        }
        for (var j = 1; j <= i; j++) {
            document.write("" + counter);
            counter--;
        }
        counter = a;
        document.write(" <br/>");
    }
    for (var i = 1; i <= a; i++) {
        document.write("&nbsp");
        for (var j = 1; j < i; j++) {
            document.write("&nbsp");
        }
        for (var j = 1; j <= (a - i); j++) {
            document.write("" + counter);
            counter--;
        }
        document.write(" <br/>");
        counter = a;
    }
}
//the manu shapes content
function menuShapeContent() {
    var option = Number(prompt("Please select shape content:\n1) * * * * *\n2) *        *\n3) 1 2 3 4 5\n 5 4 3 2 1"));
    return option;
}
//all the exeptions on the menues
function exeptions(num, flag) {
    if (flag == 1) {
        if (!((num == 1) || (num == 2) || (num == 3) || (num == 4))) {
            document.write("Error. Please select 1 or 2 or 3 or 4, for the shape type");
            return;
        }
    }
    if (flag == 2) {
        if ((num <= 0) || ((num - Math.floor(num) > 0))) {
            document.write("Error. Please enter positive integer number");
            return;
        }
    }
    if (flag == 3) {
        if (!((num == 1) || (num == 2) || (num == 3) || (num == 4))) {
            document.write("Error. Please select 1 or 2 or 3 or 4, for the shape type");
            return;
        }
    }
}
//function which called when the user want to draw square. on this function the user also choose which shape content of square he/she wants
function setSquare() {
    var sideLength = Number(prompt("Please enter square side length:"));
    exeptions(sideLength, 2);
    var option = menuShapeContent();
    switch (option) {
        case 1:
            printFullSquare(sideLength);
            break;
        case 2:
            printHollowSquare(sideLength);
            break;
        case 3:
            printUpNumbersSquare(sideLength);
            break;
        case 4:
            printDownNumbersSquare(sideLength);
            break;
        default: exeptions(option, 3);
    }
}
//function which called when the user want to draw rectangle. on this function the user also choose which shape content of rectangle he/she wants
function setRectangle() {
    var width = Number(prompt("Please enter rectangle width:"));
    var height = Number(prompt("Please enter rectangle height:"));
    exeptions(width, 2);
    exeptions(height, 2);
    var option = menuShapeContent();
    switch (option) {
        case 1:
            printFullRectangle(width, height);
            break;
        case 2:
            printHollowRectangle(width, height);
            break;
        case 3:
            printUpNumbersRectangle(width, height);
            break;
        case 4:
            printDownNumbersRectangle(width, height);
            break;
        default: exeptions(option, 3);
    }
}
//function which called when the user want to draw triangle. on this function the user also choose which shape content of triangle he/she wants
function setTriangle() {
    var sideLength = Number(prompt("Please enter triangle side length:"));
    exeptions(sideLength, 2);
    var option = menuShapeContent();
    switch (option) {
        case 1:
            printFullTriangle(sideLength);
            break;
        case 2:
            printHollowTriangle(sideLength);
            break;
        case 3:
            printUpNumbersTriangle(sideLength);
            break;
        case 4:
            printDownNumbersTriangle(sideLength);
            break;
        default: exeptions(option, 3);
    }
}
//function which called when the user want to draw diamons. on this function the user also choose which shape content of diamond he/she wants
function setDiamond() {
    var sideLength = Number(prompt("Please enter diamond side length:"));
    exeptions(sideLength, 2);
    var option = menuShapeContent();
    switch (option) {
        case 1:
            printFullDiamond(sideLength);
            break;
        case 2:
            printHollowDiamond(sideLength);
            break;
        case 3:
            printUpNumbersDiamond(sideLength);
            break;
        case 4:
            printDownNumbersDiamond(sideLength);
            break;
        default: exeptions(option, 3);
    }
}
//the main function - the first menu on the project
function main() {
    var option = Number(prompt("Welcome to the shape simulator.\nPlease select desired shape: \n1) Square \n2) Rectangle \n3) Triangle \n4)Diamond\n"));
    switch (option) {
        case 1:
            setSquare();
            break;
        case 2:
            setRectangle();
            break;
        case 3:
            setTriangle();
            break;
        case 4:
            setDiamond();
            break;
        default: exeptions(option, 1);
    }
}
//starting all the project - call the main function
main();
//# sourceMappingURL=app.js.map