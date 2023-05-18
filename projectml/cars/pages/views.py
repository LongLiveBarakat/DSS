#from msilib.schema import ListView
from multiprocessing import context
import numpy as np
from pyexpat import model
from re import template
from turtle import title
from django.shortcuts import render
import pages
#from .models import Register
import pickle

model = pickle.load(open('/Users/macbookpro/Desktop/projectml/cars/pages/models/CarsModel.pkl', 'rb'))


def home(request):
    if request.method == 'POST':
        year = request.POST['year']
        # trans = request.POST['trans']
        mil = request.POST['mil']
        # ft = request.POST['ft']
        tax = request.POST['tax']
        mpg = request.POST['mpg']
        es = request.POST['es'] 
        arr = [year, mil, tax, mpg, es]
        y_pred = model.predict(np.array([arr], dtype=float))
        return render(request, "home.html", {'result'  : round(y_pred [0])})
    return render(request, 'home.html')

