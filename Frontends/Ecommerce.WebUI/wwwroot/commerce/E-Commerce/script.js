
  
    // Küçük resimlere hover ile ana resmi güncelle
    window.changeImage = function(thumbnail) {
      if (mainImage) {
        mainImage.src = thumbnail.src.replace('100/100', '600/600');
        // Güncel index'i ayarla
        const idx = images.findIndex(src => src === mainImage.src);
        currentIndex = idx !== -1 ? idx : 0;
      }
    };
  
    // Tab switching (Ürün Açıklaması, Yorumlar, İptal & İade)
    const tabButtons = document.querySelectorAll('.tab-btn');
    const tabContents = document.querySelectorAll('.tab-content');
    tabButtons.forEach(btn => {
      btn.addEventListener('click', () => {
        tabButtons.forEach(button => button.classList.remove('active'));
        btn.classList.add('active');
        tabContents.forEach(content => content.classList.add('hidden'));
        const tabId = btn.dataset.tab;
        const tab = document.getElementById(tabId);
        if (tab) {
          tab.classList.remove('hidden');
        }
      });
    });
  
    // Rating alanına tıklayınca yorumlar bölümüne focus
    const focusReviewsElements = [];
    const focusReview1 = document.getElementById('focusReviews');
    const focusReviewText = document.getElementById('focusReviewsText');
    if (focusReview1) focusReviewsElements.push(focusReview1);
    if (focusReviewText) focusReviewsElements.push(focusReviewText);
    focusReviewsElements.forEach(el => {
      el.addEventListener('click', () => {
        const reviews = document.getElementById('reviews');
        if (reviews) {
          reviews.scrollIntoView({ behavior: 'smooth' });
        }
      });
    });
  
    // Renk seçimi: Tıklanan butona mavi border ekle
 
    // Boyut seçimi: Tıklanan butona mavi arka plan ve beyaz metin ekle
    window.selectSize = function(el) {
      document.querySelectorAll('.size-option').forEach(btn => btn.classList.remove('bg-blue-500','text-white'));
      el.classList.add('bg-blue-500','text-white');
    };
  });
  // Back to Top Button İşlevi
const backToTop = document.getElementById('backToTop');

window.addEventListener('scroll', () => {
  if (window.scrollY > 300) {  // 300px'den fazla kaydırıldığında buton görünür olur
    backToTop.style.opacity = '1';
  } else {
    backToTop.style.opacity = '0';
  }
});

backToTop.addEventListener('click', () => {
  window.scrollTo({
    top: 0,
    behavior: 'smooth'
  });
});
document.addEventListener('DOMContentLoaded', () => {
  // Tüm slider kapsayıcılarını seçiyoruz.
  const sliderContainers = document.querySelectorAll('.products-slider');

  sliderContainers.forEach((sliderContainer) => {
    // Slider içeriğini (ürün kartlarının bulunduğu flex kapsayıcı) seçiyoruz.
    const slider = sliderContainer.querySelector('div.flex');
    // Sol ve sağ ok butonlarını, sadece ilgili kapsayıcı içerisinden seçiyoruz.
    const slideLeftBtn = sliderContainer.querySelector('.slide-left');
    const slideRightBtn = sliderContainer.querySelector('.slide-right');

    let currentScroll = 0;
    const scrollAmount = 300; // Bu değeri ihtiyaçlarınıza göre ayarlayın.

    // Sol oka tıklanınca
    slideLeftBtn.addEventListener('click', () => {
      currentScroll = Math.max(currentScroll - scrollAmount, 0);
      slider.style.transform = `translateX(-${currentScroll}px)`;
    });

    // Sağ oka tıklayınca
    slideRightBtn.addEventListener('click', () => {
      const maxScroll = slider.scrollWidth - sliderContainer.offsetWidth;
      currentScroll = Math.min(currentScroll + scrollAmount, maxScroll);
      slider.style.transform = `translateX(-${currentScroll}px)`;
    });
  });
});
// Sayfadaki tüm fa-heart ikonlarını seçiyoruz
document.querySelectorAll('i.fa-heart').forEach(icon => {
  // İkonun bulunduğu en yakın button'a tıklama olayı ekliyoruz
  const btn = icon.closest('button');
  if (btn) {
    btn.addEventListener('click', (e) => {
      e.preventDefault();
      // Outline (far) sınıfını kaldırıp solid (fas) sınıfını ekliyoruz
      icon.classList.remove('far');
      icon.classList.add('fas');
      
      // Kalıcı kırmızı rengi ekliyoruz
      icon.classList.add('heart-active');
      
      // Animasyon sınıfını ekleyip, animasyon bitince kaldırıyoruz
      icon.classList.add('animate-heart');
      setTimeout(() => {
        icon.classList.remove('animate-heart');
      }, 500);
    });
  }
});
document.addEventListener('DOMContentLoaded', () => {
  const addresses = document.querySelectorAll('.truncate-address');
  
  addresses.forEach(addr => {
    const fullText = addr.textContent.trim();
    const words = fullText.split(/\s+/);
    
    if (words.length > 2) {
      // Eğer ikinci kelime "Sokak" ise kısalt
      if (words[1].toLowerCase() === 'sokak') {
        words[1] = 'Sok.';
      }
      const truncated = words.slice(0, 2).join(' ');
      addr.textContent = truncated + '...';
    }
  });
});
document.addEventListener('DOMContentLoaded', () => {
  // Tüm "Sepete Ekle" butonlarını seçiyoruz
  document.querySelectorAll('.add-to-cart').forEach(button => {
    button.addEventListener('click', (e) => {
      e.preventDefault();
      
      // Ürün kartındaki resmi buluyoruz
      const productCard = button.closest('.product-card, .bg-white'); // Ürün kartınızın ortak kapsayıcısı
      const productImage = productCard ? productCard.querySelector('img') : null;
      
      // Sepet ikonunu buluyoruz (her iki sayfada da id="cartIcon" olmalı)
      const cartIcon = document.getElementById('cartIcon');
      
      if (productImage && cartIcon) {
        // Ürün resminin kopyasını oluşturuyoruz
        const flyingImg = productImage.cloneNode(true);
        const imgRect = productImage.getBoundingClientRect();
        
        // Kopya resme "flying-img" sınıfı veriyoruz ve başlangıç konumunu ayarlıyoruz
        flyingImg.classList.add('flying-img');
        flyingImg.style.left = imgRect.left + 'px';
        flyingImg.style.top = imgRect.top + 'px';
        flyingImg.style.width = imgRect.width + 'px';
        flyingImg.style.height = imgRect.height + 'px';
        flyingImg.style.opacity = '1';
        
        document.body.appendChild(flyingImg);
        
        // Sepet ikonunun koordinatlarını alıyoruz
        const cartRect = cartIcon.getBoundingClientRect();
        
        // Bir sonraki frame'de animasyonu başlatıyoruz
        requestAnimationFrame(() => {
          flyingImg.style.left = cartRect.left + 'px';
          flyingImg.style.top = cartRect.top + 'px';
          flyingImg.style.width = '0px';
          flyingImg.style.height = '0px';
          flyingImg.style.opacity = '0';
        });
        
        // Animasyon tamamlandığında kopyayı kaldırıp sepet ikonuna bump animasyonu ekliyoruz
        setTimeout(() => {
          flyingImg.remove();
          cartIcon.classList.add('cart-bump');
          setTimeout(() => {
            cartIcon.classList.remove('cart-bump');
          }, 500);
        }, 1000);
      }
    });
  });
});
document.addEventListener("DOMContentLoaded", function () {
    const items = document.querySelectorAll(".carousel-item");
    let currentIndex = 0;
    const totalItems = items.length;

    const showSlide = (index) => {
        items.forEach((item, i) => {
            // Geçiş efektleri için opacity sınıflarını değiştiriyoruz
            if (i === index) {
                item.classList.remove("opacity-0");
                item.classList.add("opacity-100");
            } else {
                item.classList.remove("opacity-100");
                item.classList.add("opacity-0");
            }
        });
    }

    document.getElementById("prev").addEventListener("click", () => {
        currentIndex = (currentIndex === 0) ? totalItems - 1 : currentIndex - 1;
        showSlide(currentIndex);
    });

    document.getElementById("next").addEventListener("click", () => {
        currentIndex = (currentIndex === totalItems - 1) ? 0 : currentIndex + 1;
        showSlide(currentIndex);
    });

    // Otomatik geçiş (5 saniyede bir)
    setInterval(() => {
        currentIndex = (currentIndex === totalItems - 1) ? 0 : currentIndex + 1;
        showSlide(currentIndex);
    }, 5000);
});

