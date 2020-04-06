let count= 0;
$(() => {
    $("#add-person").on('click', ()=> {
        count++;
        $("#form").append(`<br/> <br/> <input name='Person[${count}].FirstName' class='form-control' placeholder='First Name' />` +
            `<input name='Person[${count}].LastName' class='form-control' placeholder='Last Name' />` +
            `<input name='Person[${count}].Age' class='form-control' placeholder='Age' />`)
    });

});