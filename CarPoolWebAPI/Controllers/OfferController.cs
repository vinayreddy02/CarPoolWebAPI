﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarPoolApplication.Models;
using CarPoolApplication.Services;
using CarPoolApplication.Services.Intefaces;

namespace CarPoolWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        readonly IOfferServices OfferServices;
        public OfferController(IOfferServices services)
        {
            OfferServices = services;
        }
        // GET: api/Offer
        [HttpGet]
        [Route("api/[controller]/GetOffers")]
        public List<Offer> GetOffers()
        {
            return OfferServices.GetAll();
        }
        // POST: api/Offer
        [HttpPost]
        [Route("api/[controller]")]
        public bool PostUser(Offer offer)
        {
            if (OfferServices.AddOffer(offer))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // GET: api/Offer/5
        [HttpGet]
        [Route("api/[controller]/{id}")]
        public Offer GetOffer(string id)
        {
            return OfferServices.GetOffer(id);
        }
        // DELETE: api/Offer/5
        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public bool DeleteOffer(string id)
        {
            if (OfferServices.DeleteOffer(id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // PUT: api/Offer/5
        [HttpPut]
        [Route("api/[controller]/{id}")]
        public string PutOffer(string id, Offer offer)
        {
            if (id != offer.Id)
            {
                return "Station does not exists";
            }
            else
            {
                if (OfferServices.UpdateOffer(offer))
                {
                    return "updated";
                }
                else
                {
                    return "Update failed";
                }
            }
        }
        [HttpGet]
        [Route("api/[controller]/AllAvailableOffers/{fromLocationId}/{toLocationId}/{numberOfSeats:int}/{dateTime:DateTime}")]
        // GET: api/Offer/AllAvailableOffers
        public List<Offer> AllAvailableOffers(string fromLocationId, string toLocationId, int numberOfSeats, DateTime dateTime)
        {
            return OfferServices.GetAvilableOffers(fromLocationId, toLocationId, numberOfSeats, dateTime);
        }
        [HttpGet]
        [Route("api/[controller]/CancelRide/{offerId}")]
        // GET: api/Offer/CancelRide
        public bool CancelRide(string offerId)
        {
            if (OfferServices.CancelRide(offerId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        [HttpGet]
        [Route("api/[controller]/EndRide/{offerId}")]
        // GET: api/Offer/EndRide
        public bool EndRide(string offerId)
        {
            if (OfferServices.EndRide(offerId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        [HttpGet]
        [Route("api/[controller]/CloseOffer/{offerId}")]
        // GET: api/Offer/CloseOffer
        public bool CloseOffer(string offerId)
        {
            if (OfferServices.CloseOffer(offerId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        [HttpGet]
        [Route("api/[controller]/StartRide/{offerId}")]
        // GET: api/Offer/StartRide
        public bool StartRide(string offerId)
        {
            if (OfferServices.StartRide(offerId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        [HttpGet]
        [Route("api/[controller]/GetOffersUsingUserId/{userId}")]
        // GET: api/Offer/GetOffersUsingUserId
        public List<Offer> GetOffersUsingUserId(string userId)
        {
            return OfferServices.GetOffers(userId);
        }
    }
}