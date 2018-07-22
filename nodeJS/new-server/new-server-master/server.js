
const express =require('express');
const app= express();
const http = require("http");
const sub1 = require("./app.js");
const fs=require("fs");



app.use(express.static('./'))
 app.get('/',(request, response)=>{
		
  var html= sub1.checkTime();
  console.log(html);
	response.writeHead(200, {"Content-Type": "text/html"});

	
fs.readFile(html,null,function( error,data){
if(error){
	response.writeHead(404);
	response.write("File not found!");
	console.log(data);
}
else{
	
	response.write(data);
}
response.end();
});
	
	
});
app.get('/Morning/:id',(request, response)=>{
	response.send(request.params)
	console.log(request.query.id);
});
app.listen(3000);

