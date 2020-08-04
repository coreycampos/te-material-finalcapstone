<template>
    <div class="upload-container-root">
        <h2>Upload a File</h2>
        <h3>Choose a file to .csv file to upload 'Harvest Times', 'Transplant Times', 'Expiration Times', or 'Crop Plans'</h3>
        <form id="fileUploadForm">
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
            <br><input type="submit" class="uploadCSVButton" v-on:click.prevent="uploadCSVFile()"/>
        </form>
        <section id="csvFileStructure">
            <h3>*Structure of your .csv files*</h3>
            <h4>Harvest Times</h4>
            <p>crop, direct_seed_to_harvest_time(days), crop, direct_seed_to_harvest_time, etc.
                <br>e.g. carrot, 70, turnip, 45, pepper, 65, etc.</p>
            <h4>Transplant Times</h4>
            <p>crop, direct_seed_to_transplant_time(days), transplant_to_harvest_time(days), etc.
                <br>e.g. cauliflour, 21, 80, tomato, 18, 110, etc.</p>
            <h4>Expiration Times</h4>
            <p>crop, days_to_expire(days), etc.
                <br>e.g. spinach, 3, summer squash, 30, etc.</p>
            <h4>Crop Plans</h4>
            <p>area_identifier, crop, planting_date(mmddyyyy), etc.
                <br>e.g. raised bed 4, garlic, 05012020, container 2, black beans, 05222020, etc.</p>
        </section>
    </div>
</template>

<script>
import uploadService from '../services/UploadService.js';

export default {
    name: "upload-files",
    data() {
        return {
            selectedFileType: "",
            selectedCSVFile: null,
        };
    },
    methods: {
        onFileChange(e) {
            console.log(e.target.files[0])
            this.selectedCSVFile = e.target.files[0];
        },
        uploadCSVFile() {
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
                uploadService.uploadFile(file, type)
                    .then(response => {
                        if (response.status == '201') {
                            console.log("successfully uploaded");
                            if (this.$router.currentRoute.name !== 'home') {
                                this.$router.push({name: 'home'});
                            }
                        }
                    })
                    .catch(error => {
                        console.error(error);
                    })
            }
        },
        
    }

}
</script>

<style>


</style>