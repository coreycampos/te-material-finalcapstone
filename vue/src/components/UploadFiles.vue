<template>
    <div class="upload-container-root">
        <h2>Upload a File</h2>
        <form id="fileUploadForm" v-on:submit.prevent="uploadCSVFile">
            <div id="fileTypeSelectors">
                <div class="radio-selector">
                    <input type="radio" id="harvestTimes" name="fileTypeSelector" value="harvestTimes" v-model="selectedFileType">
                    <label for ="harvestTimes">&nbsp; Harvest Times</label>
                </div>
                <div class="radio-selector">
                    <input type="radio" id="transplantTimes" name="fileTypeSelector" value="transplantTimes" v-model="selectedFileType">
                    <label for ="transplantTimes">&nbsp; Transplant Times</label>
                </div>
                <div class="radio-selector">
                    <input type="radio" id="expirationTimes" name="fileTypeSelector" value="expirationTimes" v-model="selectedFileType">
                    <label for ="expirationTimes">&nbsp; Expiration Times</label>
                </div>
                <div class="radio-selector">
                    <input type="radio" id="cropPlans" name="fileTypeSelector" value="cropPlans" v-model="selectedFileType">
                    <label for ="cropPlans">&nbsp; Crop Plans</label>
                </div>
            </div>
            <label for ="csvFileUploader">Select a .csv file &nbsp;</label>
            <input type="file" id="csvFileUploader" name="csvFileUploader" v-on:change="onFileChange">
            <br><input type="submit" class="uploadCSVButton"/>
        </form>
        <section id="csvFileStructure">
            <h3>Structure of your .csv files</h3>
            <h4>Harvest Times</h4>
            <img src="../assets/images/HarvestTimesFormat.jpg" />
            <p></p>
            <h4>Transplant Times</h4>
            <img src="../assets/images/TransplantTimesFormat.jpg" />
            <p></p>
            <h4>Expiration Times</h4>
            <img src="../assets/images/ExpirationTimesFormat.jpg" />
            <p></p>
            <h4>Crop Plans</h4>
            <img src="../assets/images/CropPlansFormat.jpg" />
            <p></p>
        </section>
    </div>
</template>

<script>
import uploadService from '../services/UploadService.js';
// import router from '../router/index.js';

export default {
    name: "upload-files",
    data() {
        return {
            selectedFileType: "",
            selectedCSVFile: null,
        };
    },
    methods: {
        csvFileToJSON (csvFile, callback) {
            let reader = new FileReader();
            reader.readAsText(csvFile);
            
            reader.onload = function() {
                console.log(reader.result);
                let lines = reader.result.split("\n");
                let resultObjects = [];
                let headers = lines[0].split(",");
                for (let i=1; i<lines.length; i++) {
                    let currentObject = {};
                    let currentLine = lines[i].split(",");
                    for (let j=0; j<headers.length; j++) {
                        let header = headers[j].trim()
                        currentObject[header] = currentLine[j].trim()
                    }
                    resultObjects.push(currentObject);
                }
                // console.log(resultObjects);
                // parsedCSV = resultObjects;
                
                //console.log(JSON.stringify(resultObjects));
                callback(resultObjects)
            };
        },
        onFileChange(e) {
            console.log(e.target.files[0])
            this.selectedCSVFile = e.target.files[0];
        },
        uploadCSVFile() {
            // let formData = new FormData();
            let file = this.selectedCSVFile;
            let type = this.selectedFileType;
            const fileType = ".csv";

            if (!file.name.endsWith(fileType)) {
                alert('Sorry, only .csv files are allowed.');
                //$("#csvFileUploader").val('');
                //this.$refs.csvFileUploader.val('');
                //this.input.value='';
            }
            else if (type == "") {
                alert('Please choose one of the file designation options.');
            }
            else {
                this.csvFileToJSON(file, function(result) {
                    console.log(result)
                    uploadService.uploadFile(type, result)
                    .then(response => {
                        if (response.status == '201' || response.status == '200') {
                            console.log("successfully uploaded");
                            if (this.$router.name !== 'home') {
                                this.$router.push({name: 'home'});
                            }
                        }
                    })
                    .catch(error => {
                        console.error(error);
                    })
                })
            }
            //this.$router.push({name: 'Home'});
        },
        
    }

}
</script>

<style scoped>
h3{
    text-decoration: underline;
    padding-top: 10px;
}
</style>