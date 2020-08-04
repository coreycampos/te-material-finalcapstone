<template>
    <div class="upload-container-root">
        <h2>Upload a File</h2>
        <h3>Choose a file to .csv file to upload 'Harvest Times', 'Transplant Times', 'Expiration Times', or 'Crop Plans'</h3>
        <form id="fileUploadForm">
            <div id="fileTypeSelectors">
                <div class="radio-selector">
                    <input type="radio" id="harvestTimes" name="fileTypeSelector" value="harvestTimes">
                    <label for ="harvestTimes">&nbsp; Harvest Times</label>
                </div>
                <div class="radio-selector">
                    <input type="radio" id="transplantTimes" name="fileTypeSelector" value="transplantTimes">
                    <label for ="transplantTimes">&nbsp; Transplant Times</label>
                </div>
                <div class="radio-selector">
                    <input type="radio" id="expirationTimes" name="fileTypeSelector" value="expirationTimes">
                    <label for ="expirationTimes">&nbsp; Expiration Times</label>
                </div>
                <div class="radio-selector">
                    <input type="radio" id="cropPlans" name="fileTypeSelector" value="cropPlans">
                    <label for ="cropPlans">&nbsp; Crop Plans</label>
                </div>
            </div>
            <label for ="csvFileUploader">Select a .csv file &nbsp;</label>
            <input type="file" id="csvFileUploader" name="csvFileUploader">
            <br><input type="submit"/>
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
export default {

}
</script>

<style>


</style>