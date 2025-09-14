document.addEventListener('DOMContentLoaded', function() {
    // =====================
    // NAVIGATION HIGHLIGHTING
    // =====================
    function highlightActiveNav() {
        const currentPage = location.pathname.split('/').pop();
        document.querySelectorAll('.navbar-nav .nav-link').forEach(link => {
            if (link.getAttribute('href') === currentPage) {
                link.classList.add('active');
            } else {
                link.classList.remove('active');
            }
        });

        // Special case for login button
        if (currentPage === 'login.html') {
            const loginBtn = document.querySelector('.navbar-nav .btn');
            if (loginBtn) loginBtn.classList.add('active');
        }
    }

    // =====================
    // STATUS CARD HANDLER
    // =====================
    function setupStatusCards() {
        const statusCards = document.querySelectorAll('.status-card');
        if (statusCards.length === 0) return;
        
        statusCards.forEach(card => {
            card.addEventListener('click', function() {
                const status = this.getAttribute('data-status');
                window.location.href = `complaints.html?status=${status}`;
            });
        });
    }

    // =====================
    // QUICK COMPLAINT BUTTON
    // =====================
    function setupQuickComplaintButton() {
        const quickBtn = document.querySelector('.quick-complaint-btn a');
        if (!quickBtn) return;
        
        quickBtn.addEventListener('mouseenter', function() {
            const icon = this.querySelector('i');
            if (icon) icon.classList.add('fa-bounce');
        });
        
        quickBtn.addEventListener('mouseleave', function() {
            const icon = this.querySelector('i');
            if (icon) icon.classList.remove('fa-bounce');
        });
    }

    // =====================
    // LOGIN FORM HANDLER
    // =====================
    function setupLoginForm() {
        const loginForm = document.getElementById('loginForm');
        if (!loginForm) return;

        loginForm.addEventListener('submit', function(e) {
            e.preventDefault();
            
            const email = document.getElementById('email')?.value;
            const password = document.getElementById('password')?.value;
            const submitBtn = loginForm.querySelector('button[type="submit"]');
            
            if (!email || !password || !submitBtn) return;
            
            submitBtn.innerHTML = '<i class="fas fa-spinner fa-spin"></i> Authenticating...';
            submitBtn.disabled = true;
            
            setTimeout(() => {
                submitBtn.innerHTML = 'Login';
                submitBtn.disabled = false;
                
                if (email && password) {
                    window.location.href = '/Visitors/Visitor/Index';
                }
            }, 1500);
        });
    }

    // =====================
    // SIGNUP FORM HANDLER
    // =====================
    function setupSignupForm() {
        const signupForm = document.getElementById('signupForm');
        if (!signupForm) return;
        
        const password = document.getElementById('password');
        const confirmPassword = document.getElementById('confirmPassword');
        
        if (password && confirmPassword) {
            confirmPassword.addEventListener('input', function() {
                if (confirmPassword.value !== password.value) {
                    confirmPassword.setCustomValidity("Passwords must match");
                } else {
                    confirmPassword.setCustomValidity("");
                }
            });
        }

        signupForm.addEventListener('submit', function(e) {
            e.preventDefault();
            
            if (!this.checkValidity()) {
                e.stopPropagation();
                this.classList.add('was-validated');
                return;
            }
            
            const submitBtn = signupForm.querySelector('button[type="submit"]');
            submitBtn.innerHTML = '<i class="fas fa-spinner fa-spin"></i> Creating account...';
            //submitBtn.disabled = true;
            
            //setTimeout(() => {
            //    submitBtn.innerHTML = 'Account Created!';
                
            //    setTimeout(() => {
            //        window.location.href = 'login.html';
            //    }, 1000);
            //}, 2000);
        });

        if (password) {
            password.addEventListener('input', function() {
                const strengthMeter = document.querySelector('.strength-meter');
                if (!strengthMeter) return;
                
                const strength = calculatePasswordStrength(this.value);
                strengthMeter.style.width = `${strength.percentage}%`;
                strengthMeter.style.backgroundColor = strength.color;
            });
        }
    }

    function calculatePasswordStrength(password) {
        let strength = 0;
        
        if (password.length > 7) strength += 25;
        if (password.length > 11) strength += 25;
        if (/[A-Z]/.test(password)) strength += 15;
        if (/[0-9]/.test(password)) strength += 15;
        if (/[^A-Za-z0-9]/.test(password)) strength += 20;
        
        strength = Math.min(100, strength);
        
        let color;
        if (strength < 40) color = '#dc3545';
        else if (strength < 70) color = '#ffc107';
        else color = '#28a745';
        
        return { percentage: strength, color };
    }

    // =====================
    // COMPLAINT FORM HANDLER
    // =====================
    //function setupComplaintForm() {
    //    const complaintForm = document.getElementById('complaintForm');
    //    if (!complaintForm) return;

    //    const fileInput = document.getElementById('complaintFiles');
    //    const filePreview = document.getElementById('filePreview');
        
    //    if (fileInput && filePreview) {
    //        fileInput.addEventListener('change', function() {
    //            filePreview.innerHTML = '';
                
    //            if (this.files) {
    //                Array.from(this.files).forEach(file => {
    //                    if (file.type.startsWith('image/')) {
    //                        const reader = new FileReader();
    //                        reader.onload = function(event) {
    //                            const previewItem = document.createElement('div');
    //                            previewItem.className = 'file-preview-item';
                                
    //                            const img = document.createElement('img');
    //                            img.src = event.target.result;
                                
    //                            const removeBtn = document.createElement('button');
    //                            removeBtn.className = 'remove-file';
    //                            removeBtn.innerHTML = '<i class="fas fa-times"></i>';
    //                            removeBtn.addEventListener('click', function() {
    //                                previewItem.remove();
    //                            });
                                
    //                            previewItem.appendChild(img);
    //                            previewItem.appendChild(removeBtn);
    //                            filePreview.appendChild(previewItem);
    //                        };
    //                        reader.readAsDataURL(file);
    //                    } else {
    //                        const previewItem = document.createElement('div');
    //                        previewItem.className = 'file-preview-item';
    //                        previewItem.style.display = 'flex';
    //                        previewItem.style.alignItems = 'center';
    //                        previewItem.style.justifyContent = 'center';
    //                        previewItem.style.flexDirection = 'column';
                            
    //                        const icon = document.createElement('i');
    //                        icon.className = 'fas fa-file-alt mb-2';
    //                        icon.style.fontSize = '24px';
                            
    //                        const fileName = document.createElement('span');
    //                        fileName.textContent = file.name.length > 10 ? 
    //                            file.name.substring(0, 7) + '...' : 
    //                            file.name;
    //                        fileName.style.fontSize = '12px';
    //                        fileName.style.textAlign = 'center';
                            
    //                        const removeBtn = document.createElement('button');
    //                        removeBtn.className = 'remove-file';
    //                        removeBtn.innerHTML = '<i class="fas fa-times"></i>';
    //                        removeBtn.addEventListener('click', function() {
    //                            previewItem.remove();
    //                        });
                            
    //                        previewItem.appendChild(icon);
    //                        previewItem.appendChild(fileName);
    //                        previewItem.appendChild(removeBtn);
    //                        filePreview.appendChild(previewItem);
    //                    }
    //                });
    //            }
    //        });
    //    }

    //    complaintForm.addEventListener('submit', function(e) {
    //        e.preventDefault();
            
    //        if (!this.checkValidity()) {
    //            e.stopPropagation();
    //            this.classList.add('was-validated');
    //            return;
    //        }
            
    //        const submitBtn = complaintForm.querySelector('button[type="submit"]');
    //        submitBtn.innerHTML = '<i class="fas fa-spinner fa-spin"></i> Submitting...';
    //        submitBtn.disabled = true;
            
    //        setTimeout(() => {
    //            const complaintId = 'C-' + Math.floor(1000 + Math.random() * 9000);
                
    //            const successModal = new bootstrap.Modal(document.getElementById('complaintSuccessModal'));
    //            document.getElementById('complaintIdDisplay').textContent = complaintId;
    //            successModal.show();
                
    //            submitBtn.innerHTML = 'Submit Complaint';
    //            submitBtn.disabled = false;
    //            this.reset();
    //            this.classList.remove('was-validated');
    //            document.getElementById('filePreview').innerHTML = '';
                
    //            document.getElementById('complaintSuccessModal').addEventListener('hidden.bs.modal', function () {
    //                // window.location.href = 'dashboard.html';
    //            });
    //        }, 1500);
    //    });

    //    const dateInput = document.getElementById('complaintDate');
    //    if (dateInput) {
    //        const today = new Date().toISOString().split('T')[0];
    //        dateInput.value = today;
    //        dateInput.max = today;
    //    }
    //}

    // =====================
    // TRACK COMPLAINT FORM HANDLER
    // =====================
    function setupTrackForm() {
        const trackForm = document.getElementById('trackForm');
        if (!trackForm) return;

        trackForm.addEventListener('submit', function(e) {
            e.preventDefault();
            
            if (!this.checkValidity()) {
                e.stopPropagation();
                this.classList.add('was-validated');
                return;
            }
            
            const complaintId = 'C-' + document.getElementById('complaintId').value;
            const complaintStatus = document.getElementById('complaintStatus');
            const notFoundMessage = document.getElementById('complaintNotFound');
            
            complaintStatus.style.display = 'none';
            notFoundMessage.style.display = 'none';
            
            const submitBtn = trackForm.querySelector('button[type="submit"]');
            const originalBtnText = submitBtn.innerHTML;
            submitBtn.innerHTML = '<i class="fas fa-spinner fa-spin me-1"></i> Tracking...';
            submitBtn.disabled = true;
            
            setTimeout(() => {
                const mockComplaints = {
                    'C-1234': {
                        id: 'C-1234',
                        title: 'Water leakage in apartment',
                        category: 'Water Supply',
                        date: '15 Oct 2023',
                        location: '123 Main St, Apartment 4B',
                        status: 'In Progress',
                        timeline: [
                            { stage: 'Submitted', date: '15 Oct 2023, 10:30 AM', completed: true },
                            { stage: 'Under Review', date: '16 Oct 2023, 9:15 AM', completed: true },
                            { stage: 'In Progress', date: '17 Oct 2023, 2:00 PM', completed: true },
                            { stage: 'Resolved', date: 'Pending', completed: false }
                        ]
                    },
                    'C-5678': {
                        id: 'C-5678',
                        title: 'Power outage in neighborhood',
                        category: 'Electricity Issue',
                        date: '12 Oct 2023',
                        location: '456 Oak Ave',
                        status: 'Resolved',
                        timeline: [
                            { stage: 'Submitted', date: '12 Oct 2023, 5:45 PM', completed: true },
                            { stage: 'Under Review', date: '13 Oct 2023, 8:30 AM', completed: true },
                            { stage: 'In Progress', date: '13 Oct 2023, 11:00 AM', completed: true },
                            { stage: 'Resolved', date: '14 Oct 2023, 3:15 PM', completed: true }
                        ]
                    }
                };
                
                submitBtn.innerHTML = originalBtnText;
                submitBtn.disabled = false;
                
                if (mockComplaints[complaintId]) {
                    const complaint = mockComplaints[complaintId];
                    
                    document.getElementById('detailId').textContent = complaint.id;
                    document.getElementById('detailTitle').textContent = complaint.title;
                    document.getElementById('detailCategory').textContent = complaint.category;
                    document.getElementById('detailDate').textContent = complaint.date;
                    document.getElementById('detailLocation').textContent = complaint.location;
                    
                    const statusBadge = document.getElementById('statusBadge');
                    statusBadge.textContent = complaint.status;
                    statusBadge.className = 'badge bg-' + 
                        (complaint.status === 'Resolved' ? 'success' : 
                         complaint.status === 'In Progress' ? 'primary' : 'warning');
                    
                    const timelineSteps = document.querySelectorAll('.timeline-step');
                    complaint.timeline.forEach((step, index) => {
                        if (index < timelineSteps.length) {
                            const stepElement = timelineSteps[index];
                            if (step.completed) {
                                stepElement.classList.add('active', 'completed');
                            } else {
                                stepElement.classList.remove('active', 'completed');
                            }
                            stepElement.querySelector('h6').textContent = step.stage;
                            stepElement.querySelector('p').textContent = step.date;
                        }
                    });
                    
                    complaintStatus.style.display = 'block';
                } else {
                    notFoundMessage.style.display = 'block';
                }
            }, 500);
        });
    }

   // =====================
    // FEEDBACK FORM HANDLER
    // =====================
    function setupFeedbackForm() {
        const feedbackForm = document.getElementById('feedbackForm');
        if (!feedbackForm) return;

        feedbackForm.addEventListener('submit', function(e) {
            e.preventDefault();
            
            const submitBtn = this.querySelector('button[type="submit"]');
            if (!submitBtn) return;
            
            const originalBtnText = submitBtn.innerHTML;
            submitBtn.innerHTML = '<i class="fas fa-spinner fa-spin me-2"></i> Submitting...';
            submitBtn.disabled = true;
            
            setTimeout(() => {
                submitBtn.innerHTML = '<i class="fas fa-check-circle me-2"></i> Submitted!';
                
                setTimeout(() => {
                    feedbackForm.reset();
                    submitBtn.innerHTML = originalBtnText;
                    submitBtn.disabled = false;
                    alert('Thank you for your valuable feedback!');
                }, 1500);
            }, 2000);
        });
    }

    // =====================
    // TEAM CAROUSEL
    // =====================
    function initTeamCarousel() {
        const teamCarousel = $('.team-carousel');
        if (teamCarousel.length === 0) return;

        teamCarousel.owlCarousel({
            loop: true,
            margin: 20,
            nav: false,
            dots: false,
            responsive: {
                0: { items: 1 },
                768: { items: 2 },
                992: { items: 3 }
            }
        });

        $('.team-next').click(function() {
            teamCarousel.trigger('next.owl.carousel');
        });
        $('.team-prev').click(function() {
            teamCarousel.trigger('prev.owl.carousel');
        });
    }

    // =====================
    // FEEDBACK FORM HANDLER
    // =====================
    function setupFeedbackForm() {
        const feedbackForm = $('#feedbackForm');
        if (feedbackForm.length === 0) return;

        feedbackForm.submit(function(e) {
            e.preventDefault();
            
            const submitBtn = $(this).find('button[type="submit"]');
            submitBtn.html('<i class="fas fa-spinner fa-spin me-2"></i>Submitting...');
            submitBtn.prop('disabled', true);
            
            setTimeout(() => {
                submitBtn.html('<i class="fas fa-check-circle me-2"></i>Submitted!');
                
                setTimeout(() => {
                    $('#feedbackForm')[0].reset();
                    submitBtn.html('<i class="fas fa-paper-plane me-2"></i>Submit Feedback');
                    submitBtn.prop('disabled', false);
                    
                    alert('Thank you for your valuable feedback!');
                }, 1500);
            }, 2000);
        });
    }

    // =====================
    // USER PROFILE MENU TOGGLE
    // =====================
    function setupUserProfileMenu() {
        const btn = document.getElementById('userProfileBtn');
        const menu = document.getElementById('userProfileMenu');

        if (!btn || !menu) return;

        btn.addEventListener('click', function(e) {
            e.preventDefault();
            menu.classList.toggle('show');
        });

        document.addEventListener('click', function(e) {
            if (!btn.contains(e.target) && !menu.contains(e.target)) {
                menu.classList.remove('show');
            }
        });
    }

    // =====================
    // INITIALIZE ALL FUNCTIONS
    // =====================
    function init() {
        highlightActiveNav();
        setupStatusCards();
        setupQuickComplaintButton();
        setupLoginForm();
        setupSignupForm(); 
        //setupComplaintForm();
        setupTrackForm();
        setupFeedbackForm();
        initTeamCarousel();
        setupUserProfileMenu();
    }

    // Start the application
    init();
});
