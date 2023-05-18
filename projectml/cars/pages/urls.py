from django.urls import path
from . import views

# HTML Pages 
urlpatterns = {
    path('', views.home, name='home'),
}