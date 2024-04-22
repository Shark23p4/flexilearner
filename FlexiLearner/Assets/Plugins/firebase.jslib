mergeInto(LibraryManager.library, {
    GETCONFIGINDEX: function () {
        getIndex().then(index => {
            window.unityInstance.SendMessage("Main Camera", "processInput", index);
            
            var newIndex = index + 1; // Increment the index
            if (newIndex > 3) {
                newIndex = 0;
            }
        }).catch(error => {
            console.error(error);
        });
    }
});
