namespace DUI.DataModel {
    public static class DataHelper {
        public static ReusableStream GetDataFile(string name) {
            return DataFilesHelper.GetDataFile(name);
        }
    }
}
