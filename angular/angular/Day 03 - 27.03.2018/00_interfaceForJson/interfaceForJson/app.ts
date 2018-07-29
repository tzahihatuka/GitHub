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


interface Student {
    age: number;
    eyeColor: string;
    fullName: string;
    gender: string;
    company?: string;
    email: string;
}


class JBStudent implements Student {
    constructor(age?: number,eyeColor?: string,fullName?: string, gender?: string,company?: string,email?: string) {
        this.age = age;
        this.eyeColor = eyeColor;
        this.fullName = fullName;
        this.gender = gender;
        this.company = company;
        this.email = email;
    }
    age: number;
    eyeColor: string;
    fullName: string;
    gender: string;
    company: string;
    email: string;

    describe(): string {
        return `Tel Aviv JB`;
    }

    toString(): string {
        return `JBStudent 91448-4 is the best!!!`;
    }
}

let student1: Student = {
    "age": 35,
    "eyeColor": "brown",
    "fullName": "Mayra Perry",
    "gender": "female",
    "company": "VITRICOMP",
    "email": "mayraperry@vitricomp.com"
};

let student2: Student = {
    "age": 38,
    "eyeColor": "brown",
    "fullName": "Whitney Holland",
    "gender": "female",
    "email": "whitneyholland@acruex.com"
};


//Compilation error - can not create an object from an Interface
//let student3: Student = new Student();

let student4: Student = new JBStudent(29, "blue", "Rosie Medina", "female", "PETIGEMS", "rosiemedina@petigems.com");

let student5: Student = new JBStudent();

console.log("student5", student5 + "");  //student5 JBStudent 91448-4 is the best!!!
console.log("student5", (<JBStudent>student5).describe());  //student5 Tel Aviv JB

let student6: JBStudent = {
    "age": 20,
    "eyeColor": "green",
    "fullName": "Claudette Pruitt",
    "gender": "female",
    "company": "NEXGENE",
    "email": "claudettepruitt@nexgene.com",
    "describe":()=>"Inline function from JSON"
};

console.log("student6", student6 + ""); //student6 [object Object]
console.log("student6", (<JBStudent>student6).describe());  //student6 Inline function from JSON