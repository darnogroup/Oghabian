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


function AddMail() {
    var mail = document.getElementById("mail").value;
    if (mail === "") {
        Swal.fire({
            title: 'پست الکترونیک را وارد کنید',
            icon: 'error',

            confirmButtonColor: '#3085d6',

            confirmButtonText: 'تائید',

        });
    } else {
        Swal.fire({
            title: 'آیا به خبرنامه اضافه شود؟',
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'بله اضافه شود',
            cancelButtonText: 'انصراف'
        }).then((result) => {
            if (result.isConfirmed) {
                var check = $.get("/AddMail/" + mail);
                if (check) {
                    Swal.fire({
                        title: 'به لیست خبرنامه اضافه شد',
                        icon: 'success',

                        confirmButtonColor: '#3085d6',

                        confirmButtonText: 'تائید',

                    });
                    document.getElementById("mail").value="";
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


function NewWork() {
    alert("Hello");
    var mail = document.getElementById("mail").value;
    if (mail === "") {
        Swal.fire({
            title: 'پست الکترونیک را وارد کنید',
            icon: 'error',

            confirmButtonColor: '#3085d6',

            confirmButtonText: 'تائید',

        });
    } else {
        Swal.fire({
            title: 'آیا به خبرنامه اضافه شود؟',
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'بله اضافه شود',
            cancelButtonText: 'انصراف'
        }).then((result) => {
            if (result.isConfirmed) {
                var check = $.get("/AddMail/" + mail);
                if (check) {
                    Swal.fire({
                        title: 'به لیست خبرنامه اضافه شد',
                        icon: 'success',

                        confirmButtonColor: '#3085d6',

                        confirmButtonText: 'تائید',

                    });
                    document.getElementById("mail").value="";
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
document.getElementById("computing").onclick = function () { ComputingBody() };

function ComputingBody() {
 
    var gender = document.getElementById("Gender").value;
    var active = document.getElementById("Active").value;
    var height = document.getElementById("Height").value;
    var weight = document.getElementById("Weight").value;
    var age = document.getElementById("Age").value;
    console.log(gender);
    if (height === "" || weight === "" || age === "") {
        Swal.fire({
            title: 'سن ، قد و وزن الزامی است',
            icon: 'error',

            confirmButtonColor: '#3085d6',

            confirmButtonText: 'تائید',

        });
    } else {
        var result;
        var total;
        if (gender === "male") {
             result = 88.362 + (weight * 13.397) + (height * 4.799) - (age * 5.677);
            
        } else {
             result = 447.593+ (weight * 9.247) + (height * 3.098) - (age * 4.330);
        }
        switch (active) {
            case "1":
                total=  result * 1.1;
                break;
            case "2":
                total=  result * 1.275;
                break;
            case "3":
                total=  result * 1.35;
                break;
            case "4":
                total=  result * 525;
            break;
        default:
        }
        console.log(total);
        Swal.fire({
            text: 'میزان کالری شما',
            title: Math.round(total),
            icon: 'success',

            confirmButtonColor: '#3085d6',

            confirmButtonText: 'تائید',

        });
         document.getElementById("Height").value=null;
        document.getElementById("Weight").value = null;
        document.getElementById("Age").value = null;
    }
}