function OpenWindow(WinURL)
{  
	OpenWindow2(WinURL, "", "", "")
}  

function OpenWindow2(WinURL, Options, Width, Height)
{
	var Params;
	
	if (Options!="")
		Params = Options;
	else 
	 	Params = "toolbar=yes,location=no,directories=no,status=no,menubar=yes,scrollbars=yes,resizable=yes";
	if (Width!="")
		Params = Params + ",width=" + Width; 
	else
		Params = Params + ",width=880";
	if (Height!="")
		Params = Params + ",height=" + Height; 
	else
		Params = Params + ",height=600";

	window.focus();
	
	if (WinURL != "")
	{
		aWindow = window.open(WinURL,'aWindow', Params);
		aWindow.focus();
	}
}
function Email(user, domain)
{
	window.location="mailto:"+user+"@"+domain;
	return false;
}
function trim(str) 
{
    return str.replace(/^\s+|\s+$/g,"");
}
function setCookie(name,value,days) {
    if (days) {
        var date = new Date();
        date.setTime(date.getTime()+(days*24*60*60*1000));
        var expires = "; expires="+date.toGMTString();
    }
    else var expires = "";
    document.cookie = name+"="+value+expires+"; path=/";
}

function getCookie(name) {
    var nameEQ = name + "=";
    var ca = document.cookie.split(';');
    for(var i=0;i < ca.length;i++) {
        var c = ca[i];
        while (c.charAt(0)==' ') c = c.substring(1,c.length);
        if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length,c.length);
    }
    return null;
}

function deleteCookie(name) {
    setCookie(name,"",-1);
}
