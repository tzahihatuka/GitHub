/*
כלל
_______________________________________________________________________________
בתוך ממשק אי אפשר לכתוב פונקציות עם מימוש - אלא ניתן רק להגדיר כותרת ולממש באובייקט
-----------------------------------------
בתוך מחלקה ניתן ליצור פונקציות עם מימוש לפונקציה
--
new כאשר ניצור אובייקט של מחלקה על ידי שימוש במילה
כל הפונקציות שיצרנו למחלקה - מתווספות אוטומטית לאובייקט
ויהיה להן את המימוש שכתבנו עבורן בתוך המחלקה
--
json כאשר נבצע השמה של אובייקט
לתוך משתנה מסוג המחלקה
לא נקבל אוטומטית את המימוש של הפונקציות שיצרנו במחלקה
וניצטרך לממש אותם בצורה מפורשת בתוך האובייקט המושם
------------------------------------------

מסקנה
_______________________________________________________________________________
jsonכאשר נשתמש עם אובייקטי
נעדיף להשתמש בממשק ולא במחלקה
*/
var JBStudent = (function () {
    function JBStudent(age, eyeColor, fullName, gender, company, email) {
        this.age = age;
        this.eyeColor = eyeColor;
        this.fullName = fullName;
        this.gender = gender;
        this.company = company;
        this.email = email;
    }
    JBStudent.prototype.describe = function () {
        return "Tel Aviv JB";
    };
    JBStudent.prototype.toString = function () {
        return "JBStudent 91448-4 is the best!!!";
    };
    return JBStudent;
}());
var student1 = {
    "age": 35,
    "eyeColor": "brown",
    "fullName": "Mayra Perry",
    "gender": "female",
    "company": "VITRICOMP",
    "email": "mayraperry@vitricomp.com"
};
var student2 = {
    "age": 38,
    "eyeColor": "brown",
    "fullName": "Whitney Holland",
    "gender": "female",
    "email": "whitneyholland@acruex.com"
};
//Compilation error - can not create an object from an Interface
//let student3: Student = new Student();
var student4 = new JBStudent(29, "blue", "Rosie Medina", "female", "PETIGEMS", "rosiemedina@petigems.com");
var student5 = new JBStudent();
console.log("student5", student5 + ""); //student5 JBStudent 91448-4 is the best!!!
console.log("student5", student5.describe()); //student5 Tel Aviv JB
var student6 = {
    "age": 20,
    "eyeColor": "green",
    "fullName": "Claudette Pruitt",
    "gender": "female",
    "company": "NEXGENE",
    "email": "claudettepruitt@nexgene.com",
    "describe": function () { return "Inline function from JSON"; }
};
console.log("student6", student6 + ""); //student6 [object Object]
console.log("student6", student6.describe()); //student6 Inline function from JSON
//# sourceMappingURL=app.js.map