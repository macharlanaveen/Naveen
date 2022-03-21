using AutoMapper;
using IMDBDAL.DataModel;
using IMDBDTOModel.Actor;
using IMDBDTOModel.Movie;
using IMDBDTOModel.Producer;
using MasterProjectDAL.DataModel;
using MasterProjectDTOModel.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static IMDBDTOModel.Movie.AddMovieRequestDTO;
using static IMDBDTOModel.Movie.GetMovieResponseDTO;
using static IMDBDTOModel.Movie.UpdateMovieRequestDTO;

namespace MasterProjectWebAPI.AutoMapperProfile
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            //#region Product
            //CreateMap<ProductRequest_DTO, Product>();
            //CreateMap<Product,ProductResponse_DTO>();
            //#endregion

            #region Actor
            CreateMap<AddActorRequestDTO, Actor>();
            CreateMap<Actor, int>();
            #endregion

            #region Producer
            CreateMap<ADDProducerRequestDTO, Producer>();
            CreateMap<Producer, int>();
            #endregion

            #region Movie
            CreateMap<MovieRequest, Movie>();
            CreateMap<AddMovieRequestDTO, Actorhasmovie>();
            CreateMap<Movie, int>();
            CreateMap<UpdateMovieRequestDTO, Movie>();
            CreateMap<UpdateMovieRequest, Movie>();
            CreateMap<Movie, GetMovieResponseDTO>();
            CreateMap<Actor, ActorResponse>();
            CreateMap<Movie, int>();
            #endregion
        }
    }
}
