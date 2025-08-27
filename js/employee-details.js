document.addEventListener("DOMContentLoaded", function () {
    const downloadBtn = document.getElementById("downloadBtn");
    if (!downloadBtn) return;

    downloadBtn.addEventListener("click", function () {
        const url = downloadBtn.getAttribute("data-url");
        const progressContainer = document.getElementById("progressContainer");
        const progressBar = document.getElementById("progressBar");

        progressContainer.style.display = "block";
        progressBar.style.width = "0%";
        progressBar.innerText = "0%";

        const xhr = new XMLHttpRequest();
        xhr.open("GET", url, true);
        xhr.responseType = "blob";

        xhr.onprogress = function (e) {
            if (e.lengthComputable) {
                let percent = Math.round((e.loaded / e.total) * 100);
                progressBar.style.width = percent + "%";
                progressBar.innerText = percent + "%";
            }
        };

        xhr.onload = function () {
            if (xhr.status === 200) {
                const blob = new Blob([xhr.response], { type: "application/pdf" });
                const link = document.createElement("a");
                link.href = window.URL.createObjectURL(blob);
                link.download = "Employee.pdf";
                link.click();

                progressBar.style.width = "100%";
                progressBar.innerText = "100%";

                Swal.fire({
                    icon: "success",
                    title: "Download Complete",
                    text: "Employee PDF downloaded successfully!",
                    confirmButtonColor: "#198754"
                });

                setTimeout(() => { progressContainer.style.display = "none"; }, 1500);
            }
        };

        xhr.onerror = function () {
            Swal.fire({
                icon: "error",
                title: "Oops!",
                text: "Something went wrong while downloading the PDF."
            });
            progressContainer.style.display = "none";
        };

        xhr.send();
    });
});
