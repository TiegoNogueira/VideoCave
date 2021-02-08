using AutoMapper;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using System;
using System.Collections.Generic;
using VC.Commom.Enumerables;
using VC.Domain.Interfaces;
using VC.Domain.Models;
using VC.Services.Interfaces;
using VC.Services.Models;

namespace VC.Services.Services
{
    public class SearchService : ISearchService
    {
        private readonly IVideoRepository _videoRepository;
        private readonly IMapper _mapper;
        private readonly string myYouTubeApiKey = "AIzaSyDc3Z5bw_YO0481VQhJXlLyosJnPfX9uWc";

        public SearchService(IVideoRepository videoRepository, IMapper mapper)
        {
            _mapper = mapper;
            _videoRepository = videoRepository;
        }

        public IEnumerable<VideoViewModel> Procurar(SearchParametersViewModel parameters)
        {
            IEnumerable<VideoViewModel> Videos;

            if (parameters.SearchType == SearchTypes.Channel)
                Videos = ProcurarCanais(parameters.SearchText);
            else
                Videos = ProcurarVideos(parameters.SearchText);

            return Videos;
        }

        public VideoViewModel ObterVideo(string id)
        {
            var video = _videoRepository.ObterPorId(id);

            return _mapper.Map<Video, VideoViewModel>(video);
        }

        private IEnumerable<VideoViewModel> ProcurarVideos(string searchText)
        {
            var list = new List<VideoViewModel>();

            YouTubeService youtube = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = myYouTubeApiKey
            });

            var videoRequest = youtube.Search.List("snippet");
            videoRequest.Q = searchText;
            videoRequest.Order = SearchResource.ListRequest.OrderEnum.Relevance;
            videoRequest.MaxResults = 10;

            var searchResponse = videoRequest.Execute();

            foreach (var video in searchResponse.Items)
            {
                var newVideo = new VideoViewModel() {
                    DataPublicacao = video.Snippet.PublishedAt.Value,
                    Descricao = video.Snippet.Description.Trim().Length > 2999 ? video.Snippet.Description.Trim().Substring(0, 2999) : video.Snippet.Description.Trim(),
                    Etag = video.ETag,
                    Id = video.Id.VideoId ?? new Guid().ToString(),
                    IdCanal = video.Snippet.ChannelId,
                    Titulo = video.Snippet.Title,
                    ThumbnailUrl = video.Snippet.Thumbnails.Default__.Url,
                    ThumbnailmqUrl = video.Snippet.Thumbnails.Medium.Url,
                    ThumbnailhqUrl = video.Snippet.Thumbnails.High.Url
                };

                var jaExiste = _videoRepository.ObterPorId(newVideo.Id);

                if(jaExiste == null)
                    _videoRepository.Incluir(_mapper.Map<VideoViewModel, Video>(newVideo));

                list.Add(newVideo);
            }

            _videoRepository.SaveChanges();

            return list;
        }

        private IEnumerable<VideoViewModel> ProcurarPlaylists(string searchText)
        {
            var list = new List<VideoViewModel>();

            YouTubeService youtube = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = myYouTubeApiKey
            });

            var request = youtube.Playlists.List("snippet");
            request.Mine = true;
            request.MaxResults = 10;

            var searchResponse = request.Execute();

            foreach (var video in searchResponse.Items)
            {
                var newVideo = new VideoViewModel()
                {
                    DataPublicacao = video.Snippet.PublishedAt.Value,
                    Descricao = video.Snippet.Description,
                    Etag = video.ETag,
                    Id = video.Id ?? new Guid().ToString(),
                    IdCanal = video.Snippet.ChannelId,
                    Titulo = video.Snippet.Title,
                    ThumbnailUrl = video.Snippet.Thumbnails.Default__.Url,
                    ThumbnailmqUrl = video.Snippet.Thumbnails.Medium.Url,
                    ThumbnailhqUrl = video.Snippet.Thumbnails.High.Url
                };

                list.Add(newVideo);
            }

            return list;
        }

        private IEnumerable<VideoViewModel> ProcurarCanais(string searchText)
        {
            var list = new List<VideoViewModel>();

            YouTubeService youtube = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = myYouTubeApiKey
            });

            var channelRequest = youtube.Channels.List("snippet");
            channelRequest.ForUsername = searchText;
            channelRequest.MaxResults = 10;

            var searchResponse = channelRequest.Execute();

            foreach (var video in searchResponse.Items)
            {
                var newVideo = new VideoViewModel()
                {
                    DataPublicacao = video.Snippet.PublishedAt.Value,
                    Descricao = video.Snippet.Description,
                    Etag = video.ETag,
                    Id = video.Id ?? new Guid().ToString(),
                    IdCanal = video.Id,
                    Titulo = video.Snippet.Title,
                    ThumbnailUrl = video.Snippet.Thumbnails.Default__.Url,
                    ThumbnailmqUrl = video.Snippet.Thumbnails.Medium.Url,
                    ThumbnailhqUrl = video.Snippet.Thumbnails.High.Url
                };

                list.Add(newVideo);
            }

            return list;
        }
    }
}