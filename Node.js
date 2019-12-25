var express = require('express');
var fs = require('fs');
const request = require('request');
var app = express();

app.use(function (req, response, next) 
{
   download('https://api.qrserver.com/v1/create-qr-code/?size=300x300&data=' + req.path, 'qr.png', function(){
  console.log('done');
  response.sendFile("/Users/yusuf/Desktop/qr.png");
});
})

var download = function(uri, filename, callback){
   request.head(uri, function(err, res, body){
     console.log('content-type:', res.headers['content-type']);
     console.log('content-length:', res.headers['content-length']);
 
     request(uri).pipe(fs.createWriteStream(filename)).on('close', callback);
   });
 };


var server = app.listen(8081, function () {

   var host = server.address().address
   var port = server.address().port

   console.log("Example app listening at http://%s:%s", host, port)
})
