
var time = require("./getTime.js");



function checkTime (){
  var corentTime= time.datetime.toString()
    if(corentTime>"06:00"&&corentTime<"12:00"){
        return "Morning.html";
    }
    else if(corentTime>"12:00"&&corentTime<"16:00"){
        return "afternoon.html";
    }
    else if(corentTime>"16:00"&&corentTime<"20:00"){
        return "evening.html";
    }
    else{
        return "night.html";
    }
return 
}

module.exports={
    checkTime:checkTime
}


