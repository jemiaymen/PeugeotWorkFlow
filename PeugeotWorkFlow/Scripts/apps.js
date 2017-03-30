

function initdep() {
    $('#DepartmentID').change(function () {
        var id = $('#DepartmentID').val();
        var d = JSON.parse('@Html.Raw(Json.Encode(ViewData["deps"]))');
        $('#depd').val(d[id].Budget);
        $('#depdt').val(d[id].Depense);
    });
}


   
