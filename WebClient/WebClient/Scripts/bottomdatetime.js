
function GetDate(){
    var d=new Date();
    var nmonth=d.getMonth(),ndate=d.getDate(),nyear=d.getYear();
    if(nyear<1000) nyear+=1900;

    return ""+(nmonth+1)+"/"+ndate+"/"+nyear+"";
}

function GetTime() {
    var d = new Date();
    var nhour = d.getHours(), nmin = d.getMinutes();
    if (nmin <= 9) nmin = "0" + nmin

    return "" + nhour + ":" + nmin + "";
}

function GetTimeDate() {
    var Date = GetDate();
    var time = GetTime();
}

window.onload=function(){
    GetTimeDate();
    setInterval(GetTimeDate, 1000);
}




   

