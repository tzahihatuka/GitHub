var hour=new Date();

function datetime(str){

    return(hour.toLocaleTimeString());
}


module.exports={
    datetime:datetime()
}

