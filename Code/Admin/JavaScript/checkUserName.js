var XMLHttpReq;

var resultObj_out;

//创建XMLHttpRequest对象     
function createXMLHttpRequest() {
    if (window.XMLHttpRequest) { //Mozilla 浏览器
        XMLHttpReq = new XMLHttpRequest();
    }
    else if (window.ActiveXObject) { // IE浏览器
        try {
            XMLHttpReq = new ActiveXObject("Msxml2.XMLHTTP");
        } catch (e) {
            try {
                XMLHttpReq = new ActiveXObject("Microsoft.XMLHTTP");
            } catch (e) { }
        }
    }
}

/*处理房屋信息返回的函数*/
function processCheckResponse() {
    if (XMLHttpReq.readyState == 4) { // 判断对象状态
        if (XMLHttpReq.status == 200) { // 信息已经成功返回，开始处理信息 
            resultObj_out.innerHTML = XMLHttpReq.responseText;
        } else { //页面不正常
            alert(XMLHttpReq.status);
            window.alert("您所请求的页面有异常。");
        }
    }
}


  


/*通过ajax获取验证用户名是否已经注册*/
function CheckUserName(obj,resultObj) {
    createXMLHttpRequest();
    /*为了避免浏览器读取缓存数据，加一个时间戳*/
    var timestamp = (new Date()).getTime();
    var url = "/Code/CheckUserName.aspx?username=" + obj.value + "&timestamp=" + timestamp;
    // document.write(url);
    resultObj_out = resultObj;
    XMLHttpReq.open("GET", url, true);
    XMLHttpReq.onreadystatechange = processCheckResponse; //指定响应函数
    XMLHttpReq.send(null);  // 发送请求 
    
}