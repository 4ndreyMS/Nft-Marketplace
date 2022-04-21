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

    this.pictureUploaded = function () {



    }
}