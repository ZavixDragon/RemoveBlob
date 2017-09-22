using System.Threading.Tasks;
using Amazon.Lambda.Core;
using Amazon.S3;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace RemoveBlob
{
    public class Function
    {
        public async Task<Response> FunctionHandler(Request request, ILambdaContext context)
        {
            var authorization = await new AuthorizationRequest(request.Username, request.Password).Authorize();
            if (!authorization.IsSuccess)
                return authorization;
            using (var client = new AmazonS3Client())
            {
                try
                {
                    await client.DeleteObjectAsync(request.Bucket, request.Key);
                    return new Response();
                }
                catch (AmazonS3Exception ex)
                {
                    return new Response { ErrorMessage = ex.Message };
                }
            }
        }
    }
}
