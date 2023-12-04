let isSmallScreen = window.matchMedia("(max-width: 1000px)").matches;
const eyes = document.querySelector('.eyes');
const menuLateral = document.querySelector('.menu-lateral');

const eyesOpen = document.querySelector('.eyes-open');

eyesOpen?.setAttribute('style', 'display: none');

eyes.setAttribute('style', `display: ${isSmallScreen ? 'flex' : 'none'}`);

window.matchMedia("(max-width: 1000px)").addEventListener('change', e => {
    if (e.matches) {
        eyes.setAttribute('style', 'display: flex');
    } else {
        eyes.setAttribute('style', 'display: none');
        menuLateral.setAttribute('style', 'display: flex');
        eyesOpen?.setAttribute('style', 'display: none');
    }
})

eyes.addEventListener('click', () => {
    menuLateral.setAttribute('style', 'display: none');
    eyesOpen?.setAttribute('style', 'display: flex');
})

eyesOpen?.addEventListener('click', () => {
    eyesOpen?.setAttribute('style', 'display: none');
    menuLateral.setAttribute('style', 'display: flex');
});

document.querySelector('.list-crud')?.addEventListener('submit', e => {
    e.preventDefault();
    if (document.querySelector('.list-crud input[type="text"]').value.trim().length < 5) {
        window.alert('É necessário ter no mínimo 5 caracteres');
    } else {
        e.target.submit();
    }
});
