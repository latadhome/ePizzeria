function AddToCart(ItemId, Name, UnitPrice, Quantity) {
    const extra = parseInt(document.getElementById("extraToppings").innerHTML);
    $.ajax({
        type: "GET",
        contentType: "application/json; charset=utf-8",
        url: '/Cart/AddToCart/' + ItemId + "/" + extra + "/" + Quantity,
        success: function (d) {
            var data = JSON.parse(d);
            if (data.Items.length > 0) {
                $('.noti_Counter').text(data.Items.length);

                var message = '<strong>' + Name + '</strong> Added to <a href="/cart">Cart</a> Successfully!'
                $('#toastCart > .toast-body').html(message)
                $('#toastCart').toast('show');
                setTimeout(function () {
                    $('#toastCart').toast('hide');
                }, 4000);
            }
            window.location.href = "/Home/Index/";
        },
        error: function (result) {
        }
    });
}

function AddToCart1(ItemId, Name, UnitPrice, Quantity) {
    const extra = parseInt(document.getElementById("extraToppings").innerHTML);
    $.ajax({
        type: "GET",
        contentType: "application/json; charset=utf-8",
        url: '/User/Cart/AddToCart/' + ItemId + "/" + extra + "/" + Quantity,
        success: function (d) {
            var data = JSON.parse(d);
            if (data.Items.length > 0) {
                $('.noti_Counter').text(data.Items.length);

                var message = '<strong>' + Name + '</strong> Added to <a href="/cart">Cart</a> Successfully!'
                $('#toastCart > .toast-body').html(message)
                $('#toastCart').toast('show');
                setTimeout(function () {
                    $('#toastCart').toast('hide');
                }, 4000);
            }
            window.location.href = "/User/Dashboard/Dashboard";
        },
        error: function (result) {
        }
    });
}

function deleteItem(id) {
    if (id > 0) {
        $.ajax({
            type: "GET",
            contentType: "application/json",
            url: '/Cart/DeleteItem/' + id,
            success: function (data) {
                if (data > 0) {
                    location.reload();
                }
            },
            error: function (result) {
            },
        });
    }
}
function updateQuantity(id, quantity) {
    if (id > 0) {
        $.ajax({
            type: "GET",
            contentType: "application/json",
            url: '/Cart/UpdateQuantity/' + id + '/' + quantity,
            success: function (data) {
                if (data > 0) {
                    location.reload();
                }
            },
            error: function (result) {
            },
        });
    }
}

function updateQuantity(id, quantity, value) {
    if (id > 0 ) {
        $.ajax({
            type: "GET",
            contentType: "application/json",
            url: '/Cart/UpdateQuantity/' + id + '/' + quantity,
            success: function (data) {
                if (data > 0) {
                    location.reload();
                }
            },
            error: function (result) {
            },
        });
    }
}
function updateToppingQuantity(id, quantity, value) {
    if (value == '')
        value = 0;
    const Id = id;
    const extra = parseInt(document.getElementById("extraToppings").innerHTML);

    if (value == 0 && quantity == -1)
        document.getElementById(Id).value = value
    else
    { 
        document.getElementById(Id).value = quantity + parseInt(value);
        document.getElementById('extraToppings').innerHTML = extra + quantity;
    }
}

$(document).ready(function () {
    var cookie = $.cookie('CId');
    if (cookie) {
        $.ajax({
            type: "GET",
            contentType: "application/json; charset=utf-8",
            url: '/Cart/GetCartCount',
            dataType: "json",
            success: function (data) {
                $('.noti_Counter').text(data);
            },
            error: function (result) {
            },
        });
    }
});