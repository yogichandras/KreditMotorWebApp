$('#create-gagal').hide();

$.fn.serializeFormToObject = function () {
    //serialize to array
    var data = $(this).serializeArray();

    //add also disabled items
    $(':disabled[name]', this).each(function () {
        data.push({ name: this.name, value: $(this).val() });
    });

    //map to object
    var obj = {};
    data.map(function (x) { obj[x.name] = x.value; });

    return obj;
};

$('#btn-kirim').click(function () {
    let url = $(this).attr('data-url');;
    let form = $(this).attr('data-form');
    userData(form, url);
});

$('#btn-kirim-customer').click(function () {
    let url = $(this).attr('data-url');;
    let form = $(this).attr('data-form');
    userCustomer(form, url);
});


function userData(form,url) {
    let data = $('#' + form + '').serializeFormToObject();
    fetch(url, {
        method: 'POST',
        body: JSON.stringify(data),
        headers: {
            'Content-Type': 'application/json'
        }
    }).then(res => res.json())
        .then(response => {
            if (!response.result) {
                $('#create-gagal').show();
            } else {
                location.reload();
            }
        })
        .catch(error => console.error('Error:', error));
}
function userCustomer(form, url) {
    let data = $('#' + form + '').serializeFormToObject();

    fetch(url, {
        method: 'POST',
        body: JSON.stringify(data),
        headers: {
            'Content-Type': 'application/json'
        }
    }).then(res => res.json())
        .then(response => location.reload())
        .catch(error => console.error('Error:', error));
}


function getAdmin() {
    fetch('/User/getAdmin').then(
        function (response) {
            return response.json();
        }
    ).then(function (jsonData) {
        //handle json data processing here
        var x = 1;
        var content = '';
        $.each(jsonData.result, function (i, item) {
            content += '<tr><td>' + x + '</td><td>' + item.username + '</td><td><button class="btn btn-warning item-edit" data-id="' + item.id + '" style="margin-right:10px">Edit</button><button class="btn btn-danger item-delete" data-id="' + item.id + '" style="margin-right:10px">Delete</button></td></tr>';
            x++;
        });
        $('#content').html(content);
        $("#table-1").dataTable();
        initDelete();
        initEdit();
    });
}

function getKasir(){
    fetch('/User/getKasir').then(
        function (response) {
            return response.json();

        }
    ).then(function (jsonData) {
        //handle json data processing here
        var x = 1;
        var content = '';
        $.each(jsonData.result, function (i, item) {
            content += '<tr><td>' + x + '</td><td>' + item.username + '</td><td><button class="btn btn-warning item-edit" data-id="' + item.id + '" style="margin-right:10px">Edit</button><button class="btn btn-danger item-delete" data-id="' + item.id + '">Delete</button></td></tr>';
            x++;
        });
        $('#content').html(content);
        $("#table-1").dataTable();
        initDelete();
        initEdit();
    });
}

function getCso() {
    fetch('/User/getCso').then(
        function (response) {
            return response.json();

        }
    ).then(function (jsonData) {
        //handle json data processing here
        var x = 1;
        var content = '';
        $.each(jsonData.result, function (i, item) {
            content += '<tr><td>' + x + '</td><td>' + item.username + '</td><td><button class="btn btn-warning item-edit" data-id="' + item.id + '" style="margin-right:10px">Edit</button><button class="btn btn-danger item-delete" data-id="' + item.id + '">Delete</button></td></tr>';
            x++;
        });
        $('#content').html(content);
        $("#table-1").dataTable();
        initDelete();
        initEdit();
    });
}

function getSales() {
    fetch('/User/getSales').then(
        function (response) {
            return response.json();

        }
    ).then(function (jsonData) {
        //handle json data processing here
        var x = 1;
        var content = '';
        $.each(jsonData.result, function (i, item) {
            content += '<tr><td>' + x + '</td><td>' + item.username + '</td><td><button class="btn btn-warning item-edit" data-id="' + item.id + '" style="margin-right:10px">Edit</button><button class="btn btn-danger item-delete" data-id="' + item.id + '">Delete</button></td></tr>';
            x++;
        });
        $('#content').html(content);
        $("#table-1").dataTable();
        initDelete();
        initEdit();
    });
}


function getCustomer() {
    fetch('/Customer/getCustomer').then(
        function (response) {
            return response.json();

        }
    ).then(function (jsonData) {
      
        //handle json data processing here
        var x = 1;
        var content = '';
        $.each(jsonData.result, function (i, item) {
            content += '<tr><td>' + x + '</td><td>' + item.nama_pelanggan + '</td><td>' + item.alamat + '</td><td>' + item.pekerjaan + '</td><td>' + item.no_ktp + '</td><td><button class="btn btn-warning item-edit" data-id="' + item.kd_pelanggan + '" style="margin-right:10px">Edit</button><button class="btn btn-danger item-delete" data-id="' + item.kd_pelanggan + '">Delete</button></td></tr>';
            x++;
        });
        $('#content').html(content);
        $("#table-1").dataTable();
        initDeletePelanggan();
        initEditPelanggan();
    });
}

function initDelete() {
    $('.item-delete').click(function () {
        let id = $(this).attr('data-id');
        $('#deleteModal').modal('show');
        $('#delId').val(id);
    });
    }

function initEdit() {
        $('.item-edit').click(function () {
            let id = $(this).attr('data-id');
            fetch('/User/editUser?id='+id+'').then(
                function (response) {
                    return response.json();
                }
            ).then(function (jsonData) {
                //handle json data processing here
                $('#edituser_Username').val(jsonData.username);
                $('#edituser_Id').val(jsonData.id);
                $('#edituser_Bagian').val(jsonData.bagian);
                $('#edituser_Nama').val(jsonData.nama);
                $('#edituser_Keterangan').val(jsonData.keterangan);
                $('#editModal').modal('show');
            });
        });
}


function initEditPelanggan() {
    $('.item-edit').click(function () {
        let id = $(this).attr('data-id');
        fetch('/Customer/editCustomer?id=' + id + '').then(
            function (response) {
                return response.json();
            }
        ).then(function (jsonData) {
            //handle json data processing here
            $('#edit_kd_pelanggan').val(jsonData.result.kd_pelanggan);
            $('#edit_nama_pelanggan').val(jsonData.result.nama_pelanggan);
            $('#edit_alamat').val(jsonData.result.alamat);
            $('#edit_pekerjaan').val(jsonData.result.pekerjaan);
            $('#edit_no_ktp').val(jsonData.result.no_ktp);
            $('#editModal').modal('show');
        });
    });
}

    $('#btn-delete').click(function () {
        let id = $('#delId').val();
        userDelete(id);
    });

    function userDelete(id) {
        fetch('/User/deleteUser?id=' + id + '', {
            method: 'DELETE',
            headers: {
                'Content-Type': 'application/json'
            }
        }).then(res => res.json())
            .then(location.reload())
            .catch(error => console.error('Error:', error));
}

$('#btn-kirim-edit').click(function () {
    let form = $(this).attr('data-form');
    let url = $(this).attr('data-url');
    editUserData(form,url)
});

$('#btn-kirim-edit-pelanggan').click(function () {
    let form = $(this).attr('data-form');
    let url = $(this).attr('data-url');
    editPelangganData(form, url)
});

function editUserData(form, url) {
    let id = $('#edituser_Id').val();
   let bagian = $('#edituser_Bagian').val();
   let nama = $('#edituser_Nama').val();
   let keterangan = $('#edituser_Keterangan').val();
    let parseData = {
        edituser: {
            Id: id,
            Nama: nama,
            Bagian: bagian,
            Keterangan: keterangan
        }
    }
    

    fetch(url, {
        method: 'POST',
        body: JSON.stringify(parseData),
        headers: {
            'Content-Type': 'application/json'
        }
    }).then(res => res.json())
        .then(response => console.log(location.reload()))
        .catch(error => console.error('Error:', error));
}
function editPelangganData(form, url) {
    let data = $('#' + form + '').serializeFormToObject();
    fetch(url, {
        method: 'POST',
        body: JSON.stringify(data),
        headers: {
            'Content-Type': 'application/json'
        }
    }).then(res => res.json())
        .then(response => console.log(location.reload()))
        .catch(error => console.error('Error:', error));
}

function initDeletePelanggan() {
    $('.item-delete').click(function () {
        let id = $(this).attr('data-id');
        $('#deleteModal').modal('show');
        $('#delId').val(id);
    });
}

$('#btn-delete-pelanggan').click(function () {
    let id = $('#delId').val();
    userDeletePelanggan(id);
});

function userDeletePelanggan(id) {
    fetch('/Customer/deleteCustomer?id=' + id + '', {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json'
        }
    }).then(res => res.json())
        .then(location.reload())
        .catch(error => console.error('Error:', error));
}

