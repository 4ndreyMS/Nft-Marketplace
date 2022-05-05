//const img = document.querySelector("#uploadedimage")

function CloudinaryManager() {

    this.uploadPhoto = function () {
        const btn_foto = document.querySelector("#btnPhoto");
        const image = document.querySelector("#uploadedimage");

        let widget_cloudinary = cloudinary.createUploadWidget({
            cloudName: 'andreshts',
            uploadPreset: 'preset_and',
        },
            (err, result) => {
                if (!err && result && result.event === 'success') {
                    console.log('Imagen subida con éxito', result.info);
                    image.src = result.info.secure_url;
                    var imagensubida = image.src;
                    sessionStorage.setItem("imagenLocal", imagensubida);
                    // document.getElementById('reporteDocumento').hidden = false;
                    // let pushToArray = window.urlDocumento.push(result.info.secure_url);
                }
            });

        btn_foto.addEventListener('click', () => {

            widget_cloudinary.open();

        }, false);

    }


    this.uploadUserPhoto = function () {
        const btn_foto = document.querySelector("#btnUserPhoto");
        const image = document.querySelector("#uploadedUserImage");

        let widget_cloudinary = cloudinary.createUploadWidget({
                cloudName: 'andreshts',
                uploadPreset: 'preset_and',
            },
            (err, result) => {
                if (!err && result && result.event === 'success') {
                    console.log('Imagen subida con éxito', result.info);
                    image.src = result.info.secure_url;
                    var imagensubida = image.src;
                    localStorage.setItem("UserPhoto", imagensubida);
                    // document.getElementById('reporteDocumento').hidden = false;
                    // let pushToArray = window.urlDocumento.push(result.info.secure_url);
                }
            });

        btn_foto.addEventListener('click', () => {

            widget_cloudinary.open();

        }, false);

    }

    this.uploadUserCreatorPhoto = function () {
        const btn_foto = document.querySelector("#btnUserCreatorPhoto");
        const image = document.querySelector("#ContenCreatorImage");

        let widget_cloudinary = cloudinary.createUploadWidget({
                cloudName: 'andreshts',
                uploadPreset: 'preset_and',
            },
            (err, result) => {
                if (!err && result && result.event === 'success') {
                    console.log('Imagen subida con éxito', result.info);
                    image.src = result.info.secure_url;
                    var imagensubida = image.src;
                    localStorage.setItem("UserPhoto", imagensubida);
                    // document.getElementById('reporteDocumento').hidden = false;
                    // let pushToArray = window.urlDocumento.push(result.info.secure_url);
                }
            });

        btn_foto.addEventListener('click', () => {

            widget_cloudinary.open();

        }, false);

    }

    this.updatedUserPhoto = function () {
        const btn_foto = document.querySelector("#btnUserPhotoUpd");
        const image = document.querySelector("#UserUpd");

        let widget_cloudinary = cloudinary.createUploadWidget({
                cloudName: 'andreshts',
                uploadPreset: 'preset_and',
            },
            (err, result) => {
                if (!err && result && result.event === 'success') {
                    console.log('Imagen subida con éxito', result.info);
                    image.src = result.info.secure_url;
                    var imagensubida = image.src;
                    localStorage.setItem("UserPhoto", imagensubida);
                    // document.getElementById('reporteDocumento').hidden = false;
                    // let pushToArray = window.urlDocumento.push(result.info.secure_url);
                }
            });

        btn_foto.addEventListener('click', () => {

            widget_cloudinary.open();

        }, false);

    }



    this.pictureUploaded = function () {



    }
}