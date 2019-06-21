$().ready(function () {
    document.getElementById("#MainContent_pnlCountries").style.display = 'none';
});
function toggleCountries() {
    //alert("toggleCountries");
    //if ($("#divCountries").length == 0) {
    //    var elementi = "<div id='divCountries'><table><tbody><tr><td><input type='checkbox' value='Mexico' onclick='cbCountryClick(this.value)' /> Mexico</td></tr>";
    //    elementi = elementi + "<tr><td><input type='checkbox' value='Sweden' onclick='cbCountryClick(this.value)' />Sweden </td></tr> ";
    //    elementi = elementi + "</table></div > ";
    //    $("#buttons").after(elementi);

    //} else {
    //    $("#divCountries").remove();
    //}
    var div = $("#MainContent_pnlCountries");
    if ($("#MainContent_pnlCountries:visible").length)
        $("#MainContent_pnlCountries:visible").hide();
    else
        $("#MainContent_pnlCountries:visible").show();
    
};
function cbCountryClick(obj) {
    // ajax call
    alert(obj);
    $("#divCountries").remove();
}
