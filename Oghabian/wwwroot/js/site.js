function CommentArticle() {
    var text = document.getElementById("text").value;
    var id = document.getElementById("article").value;
    if (text === null || text === "") {
        Swal.fire({
            title: 'دیدگاه خالی ارسال نمی شود',
            icon: 'error',

            confirmButtonColor: '#3085d6',

            confirmButtonText: 'تائید',

        });
    } else {
        Swal.fire({
            title: 'آیا دیدگاه ثبت شود؟',
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'بله ثبت شود',
            cancelButtonText: 'انصراف'
        }).then((result) => {
            if (result.isConfirmed) {
                var check = $.get("/InsertComment/" + text + "/" + id);
                if (check) {
                    $("#item_" + id).hide('slow');
                    document.getElementById("text").value = "";
                    Swal.fire({
                        title: 'عملیات موفقیت آمیز بود',
                        icon: 'success',

                        confirmButtonColor: '#3085d6',

                        confirmButtonText: 'تائید',

                    });
                } else {


                    Swal.fire({
                        title: 'عملیات انجام نشد',
                        icon: 'error',

                        confirmButtonColor: '#3085d6',

                        confirmButtonText: 'تائید',

                    });
                }
            }
        });
    }
}

function LoginError() {
    Swal.fire({
        icon: 'error',
        title: 'وارد نشدید', confirmButtonText: 'متوجه شدم',
        text: 'لطفا وارد حساب کاربری شوید',
        footer: '<a href="/Signin">برای ورود به سایت کلیک کنید</a>'
    });
}
function CommentFood() {
    var text = document.getElementById("text").value;
    var id = document.getElementById("food").value;
    if (text === null || text === "") {
        Swal.fire({
            title: 'دیدگاه خالی ارسال نمی شود',
            icon: 'error',

            confirmButtonColor: '#3085d6',

            confirmButtonText: 'تائید',

        });
    } else {
        Swal.fire({
            title: 'آیا دیدگاه ثبت شود؟',
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'بله ثبت شود',
            cancelButtonText: 'انصراف'
        }).then((result) => {
            if (result.isConfirmed) {
                var check = $.get("/InsertFoodComment/" + text + "/" + id);
                if (check) {
                    $("#item_" + id).hide('slow');
                    document.getElementById("text").value = "";
                    Swal.fire({
                        title: 'عملیات موفقیت آمیز بود',
                        icon: 'success',

                        confirmButtonColor: '#3085d6',

                        confirmButtonText: 'تائید',

                    });
                } else {


                    Swal.fire({
                        title: 'عملیات انجام نشد',
                        icon: 'error',

                        confirmButtonColor: '#3085d6',

                        confirmButtonText: 'تائید',

                    });
                }
            }
        });
    }
}

function ChangeImage(input) {

    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#image').attr('src', e.target.result);
        }

        reader.readAsDataURL(input.files[0]);
    }
}
$("#imagePath").change(function () {
    readURL(this);
});

$(document).ready(function () {

    $("#State").change(function () {
        var id = $("#State").val();
        $.getJSON("/GetCity/" + id,
            function (res) {
                var item = "";
                $.each(res,
                    function (i, sub) {
                        item += '<option value="' + sub.value + '">' + sub.text + '</option>';
                    });
                $("#City").html(item);

            });
    });
});

function AddToCart(id) {

    Swal.fire({
        title: 'آیا به سبد خرید اضافه شود؟',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'بله اضافه شود',
        cancelButtonText: 'انصراف'
    }).then((result) => {
        if (result.isConfirmed) {
            var check = $.get("/AddToCart/" + id);
            if (check) {
                Swal.fire({
                    title: 'به سبد خرید اضافه شد',
                    icon: 'success',

                    confirmButtonColor: '#3085d6',

                    confirmButtonText: 'تائید',

                });
            } else {


                Swal.fire({
                    title: 'عملیات انجام نشد',
                    icon: 'error',

                    confirmButtonColor: '#3085d6',

                    confirmButtonText: 'تائید',

                });
            }
        }
    });
}



function AddFavorite(id) {

    Swal.fire({
        title: 'آیا به لیست علاقه مندی اضافه شود؟',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'بله اضافه شود',
        cancelButtonText: 'انصراف'
    }).then((result) => {
        if (result.isConfirmed) {
            var check = $.get("/AddFavorite/" + id);
            if (check) {
                Swal.fire({
                    title: 'به لیست علاقه مندی اضافه شد',
                    icon: 'success',

                    confirmButtonColor: '#3085d6',

                    confirmButtonText: 'تائید',

                });
            } else {


                Swal.fire({
                    title: 'عملیات انجام نشد',
                    icon: 'error',

                    confirmButtonColor: '#3085d6',

                    confirmButtonText: 'تائید',

                });
            }
        }
    });
}



function RemoveFavorite(id) {

    Swal.fire({
        title: 'آیا از لیست علاقه مندی پاک شود؟',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'بله اضافه شود',
        cancelButtonText: 'انصراف'
    }).then((result) => {
        if (result.isConfirmed) {
            var check = $.get("/RemoveFavorite/" + id);
            if (check) {
                $("#item_" + id).hide('slow');
                Swal.fire({
                    title: 'از لیست علاقه مندی پاک شد',
                    icon: 'success',

                    confirmButtonColor: '#3085d6',

                    confirmButtonText: 'تائید',

                });
            } else {


                Swal.fire({
                    title: 'عملیات انجام نشد',
                    icon: 'error',

                    confirmButtonColor: '#3085d6',

                    confirmButtonText: 'تائید',

                });
            }
        }
    });
}



function myFunction(id) {
 
    var check = $.get("/RemoveOrderDetail/" + id);
    if (check) {
       
        var delayInMilliseconds = 1000; //1 second

        setTimeout(function () {
            location.href = location.href;
        }, delayInMilliseconds);
    }
}