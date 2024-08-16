mergeInto(LibraryManager.library, {

        saveProgress: function(key, value) {
        console.log("saveProgress");
        },

        loadProgress: function() {
         console.log("loadProgress");
        },

        rewriteProgress: function(key, value) {
         console.log("rewriteProgress");
        },
});