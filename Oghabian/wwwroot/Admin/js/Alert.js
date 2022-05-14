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
function ChangeImageTwo(input) {

    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#imageTwo').attr('src', e.target.result);
        }

        reader.readAsDataURL(input.files[0]);
    }
}
$("#imagePathTwo").change(function () {
    readURL(this);
});

function ChangeImageThree(input) {

    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#imageThree').attr('src', e.target.result);
        }

        reader.readAsDataURL(input.files[0]);
    }
}
$("#imagePathThree").change(function () {
    readURL(this);
});

function DeleteMeal(id) {
    Swal.fire({
        title: 'آیا وعده غذایی پاک شود؟',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'بله پاک شود',
        cancelButtonText: 'انصراف'
    }).then((result) => {
        if (result.isConfirmed) {
            var check = $.get("/Admin/Meal/Delete/" + id);
            if (check) {
                $("#item_" + id).hide('slow');

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
function DeleteSickness(id) {
    Swal.fire({
        title: 'آیا بیماری پاک شود؟',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'بله پاک شود',
        cancelButtonText: 'انصراف'
    }).then((result) => {
        if (result.isConfirmed) {
            var check = $.get("/Admin/Sickness/Delete/" + id);
            if (check) {
                $("#item_" + id).hide('slow');

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
function DeleteState(id) {
    Swal.fire({
        title: 'آیا استان پاک شود؟',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'بله پاک شود',
        cancelButtonText: 'انصراف'
    }).then((result) => {
        if (result.isConfirmed) {
            var check = $.get("/Admin/State/Delete/" + id);
            if (check) {
                $("#item_" + id).hide('slow');

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
function DeleteCity(id) {
    Swal.fire({
        title: 'آیا شهر پاک شود؟',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'بله پاک شود',
        cancelButtonText: 'انصراف'
    }).then((result) => {
        if (result.isConfirmed) {
            var check = $.get("/Admin/City/Delete/" + id);
            if (check) {
                $("#item_" + id).hide('slow');

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
function DeleteCategory(id) {
    Swal.fire({
        title: 'آیا دسته بندی پاک شود؟',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'بله پاک شود',
        cancelButtonText: 'انصراف'
    }).then((result) => {
        if (result.isConfirmed) {
            var check = $.get("/Admin/Category/Delete/" + id);
            if (check) {
                $("#item_" + id).hide('slow');

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
function DeleteArticle(id) {
    Swal.fire({
        title: 'آیا مقاله پاک شود؟',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'بله پاک شود',
        cancelButtonText: 'انصراف'
    }).then((result) => {
        if (result.isConfirmed) {
            var check = $.get("/Admin/Article/Delete/" + id);
            if (check) {
                $("#item_" + id).hide('slow');

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
function DeleteQuestion(id) {
    Swal.fire({
        title: 'آیا سوال پاک شود؟',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'بله پاک شود',
        cancelButtonText: 'انصراف'
    }).then((result) => {
        if (result.isConfirmed) {
            var check = $.get("/Admin/Question/Delete/" + id);
            if (check) {
                $("#item_" + id).hide('slow');

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
function DeleteFood(id) {
    Swal.fire({
        title: 'آیا پک غذایی پاک شود؟',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'بله پاک شود',
        cancelButtonText: 'انصراف'
    }).then((result) => {
        if (result.isConfirmed) {
            var check = $.get("/Admin/Food/Delete/" + id);
            if (check) {
                $("#item_" + id).hide('slow');

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
function DeleteImage(id) {
    Swal.fire({
        title: 'آیا تصویر پاک شود؟',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'بله پاک شود',
        cancelButtonText: 'انصراف'
    }).then((result) => {
        if (result.isConfirmed) {
            var check = $.get("/Admin/Gallery/Delete/" + id);
            if (check) {
                $("#item_" + id).hide('slow');

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
function DeleteProperty(id) {
    Swal.fire({
        title: 'آیا ویژگی پاک شود؟',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'بله پاک شود',
        cancelButtonText: 'انصراف'
    }).then((result) => {
        if (result.isConfirmed) {
            var check = $.get("/Admin/Property/Delete/" + id);
            if (check) {
                $("#item_" + id).hide('slow');

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

function DeleteSupporter(id) {
    Swal.fire({
        title: 'آیا شریک تجاری پاک شود؟',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'بله پاک شود',
        cancelButtonText: 'انصراف'
    }).then((result) => {
        if (result.isConfirmed) {
            var check = $.get("/Admin/Supporter/Delete/" + id);
            if (check) {
                $("#item_" + id).hide('slow');

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
function DeleteSlider(id) {
    Swal.fire({
        title: 'آیا تصویر پاک شود؟',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'بله پاک شود',
        cancelButtonText: 'انصراف'
    }).then((result) => {
        if (result.isConfirmed) {
            var check = $.get("/Admin/Slider/Delete/" + id);
            if (check) {
                $("#item_" + id).hide('slow');

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