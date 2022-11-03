// See https://aka.ms/new-console-template for more information
using DoodStream.Code;

var upload = new UploadAPI("Key");

var data = upload.UploadFile("path").Result;
