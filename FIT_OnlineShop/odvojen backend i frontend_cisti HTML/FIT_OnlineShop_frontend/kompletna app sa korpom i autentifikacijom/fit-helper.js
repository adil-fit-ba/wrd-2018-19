

function redirekcija(filename) {
    window.open(filename, "_self");
}

function getMojToken() {
    return localStorage.getItem("nasToken");
}

function setMojToken(tokenVrijednost) {
    localStorage.setItem("nasToken", tokenVrijednost);
}


function KomunikacijaGreska() {
    porukaError("Greška u komunikaciji sa serverom.");
};

function saveKorpaMap(map) {
    var jsonKorpa = JSON.stringify([...map]);
    localStorage.setItem("korpa", jsonKorpa);
}
function getKorpaMap() {
    var jsonKorpa = localStorage.getItem("korpa");
    return new Map(JSON.parse(jsonKorpa));
}

function UcitajHtml(url, divId) {
        
    var divKontejner = document.getElementById(divId);
    var zahtjev = new XMLHttpRequest();
  
    zahtjev.onload = function (e) { 
      if (zahtjev.status == 200) {
          divKontejner.innerHTML = zahtjev.responseText;
      }
    }
  
    zahtjev.open("GET", url, true);
    zahtjev.send();
  }