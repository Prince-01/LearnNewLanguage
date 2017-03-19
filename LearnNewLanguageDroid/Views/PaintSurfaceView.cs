using System;
using System.IO;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Util;
using Android.Views;
using Android.Widget;
using Com.Googlecode.Leptonica.Android;
using Java.Nio;
using Tesseract.Droid;
using Path = Android.Graphics.Path;
using LearnNewLanguageDroid.LearnLanguage;

namespace LearnNewLanguageDroid.Views
{
    public class PaintSurfaceView : SurfaceView
    {
        private Paint _mPaint;
        private Path _path;
        private TesseractApi _tesseractApi;
        private Bitmap _bitmap;
        private Canvas _canvas;
        public string currentText;

        private CallOnce setWhitelist;

        public PaintSurfaceView(Context context, IAttributeSet attrs) :
            base(context, attrs)
        {
            Initialize();
        }

        public PaintSurfaceView(Context context, IAttributeSet attrs, int defStyle) :
            base(context, attrs, defStyle)
        {
            Initialize();
        }

        public string Whitelist
        {
            set
            {
                _tesseractApi.SetWhitelist(value);
            }
        }

        private void Initialize()
        {
            _tesseractApi = new TesseractApi(Context, AssetsDeployment.OncePerVersion);
            setWhitelist = new CallOnce(() => { _tesseractApi.SetWhitelist("あいうえおかきくけこさしすせそたちつてとなにぬねのはひふへほまみむめももやゆよらりるれろわゐゑをがぎぐげござじずぜぞだぢづでどばびぶべぼぱぴぷぺぽんアイウエオカキクケコサシスセソタチツテトナニヌネノハヒフヘホマミムメモヤユヨラリルレロワヲン"); });
            currentText = string.Empty;

            SetBackgroundColor(Color.White);
            _path = new Path();
            _mPaint = new Paint
            {
                Dither = true,
                Color = Color.Black,
                StrokeJoin = Paint.Join.Round,
                StrokeCap = Paint.Cap.Round,
                StrokeWidth = 15
            };
            _mPaint.SetStyle(Paint.Style.Stroke);
            _tesseractApi.Init("jpn");
        }

        public void ClearCanvas()
        {
            _path = new Path();
        }

        public override bool OnTouchEvent(MotionEvent ev)
        {
            if (_canvas == null)
            {
                _bitmap = Bitmap.CreateBitmap(Width, Height, Bitmap.Config.Argb8888);
                _canvas = new Canvas(_bitmap);
            }
            _canvas.DrawColor(Color.White);
            _canvas.DrawPath(_path, _mPaint);

            switch (ev.Action)
            {
                case MotionEventActions.Down:
                    _path.MoveTo(ev.GetX(), ev.GetY());
                    _path.LineTo(ev.GetX(), ev.GetY());
                    break;
                case MotionEventActions.Move:
                    _path.LineTo(ev.GetX(), ev.GetY());
                    break;
                case MotionEventActions.Up:
                    var stream = new MemoryStream();

                    _bitmap.Compress(Bitmap.CompressFormat.Jpeg, 100, stream);

                    OCR(stream.ToArray());
                    break;
            }
            Invalidate();
            return true;
        }

        public void OCR(byte[] bmp)
        {
            if (!_tesseractApi.Initialized)
                return;

            setWhitelist.Call();
            _tesseractApi.SetImage(bmp).ContinueWith(r =>
            {
                currentText = _tesseractApi.Text;
                Toast.MakeText(Context, string.Format("Did you mean: {0}?", currentText), ToastLength.Long).Show();
            });

        }

        protected override void OnDraw(Canvas canvas)
        {
            base.OnDraw(canvas);

            canvas.DrawPath(_path, _mPaint);
        }

        public class PathWithPaint
        {
            public Path Path { get; set; }
            public Paint MPaint { get; set; }
        }
    }
}