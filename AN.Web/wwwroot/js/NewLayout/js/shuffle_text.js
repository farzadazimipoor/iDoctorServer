(function() {
  //Shuffle texts
  var shuffleTexts = Array.prototype.slice.call(
    document.querySelectorAll('.shuffle-txt'),
  );

  var length = shuffleTexts.length;

  setInterval(function() {
    var index = shuffleTexts.findIndex(t =>
      t.classList.contains('txt--active'),
    );
    var newIndex = (1 + index + length) % length;
    shuffleTexts.map(function(t) {
      t.classList.remove('txt--deactive');
    });
    shuffleTexts[index].classList.add('txt--deactive');
    shuffleTexts[index].classList.remove('txt--active');

    shuffleTexts[newIndex].classList.remove('txt--deactive');
    shuffleTexts[newIndex].classList.add('txt--active');
  }, 1500);
})();
